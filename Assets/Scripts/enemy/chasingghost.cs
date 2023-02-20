using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasingghost : MonoBehaviour
{
    // Ghost AI State
    private enum GhostState {IDLE, CHASE };
    [SerializeField] private GhostState curState;
    
    // Sprite and Opacity
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private float targetOpacity = 0.8f;
    private float spriteOpacity;

    [Range(0.02f, 0.1f)]
    [SerializeField] private float appearSpeed = 0.05f;
    [SerializeField] private float movementSpeed = 10f;

    // Player target
    private Transform Player;

    // Checks for ghost is showing or hiding and if its in contact with player
    private bool isActive;
    private bool inContactWithPlayer;

    // Time to hide / show ghost after x seconds
    [SerializeField] private float hideGhostAfter, showGhostAfter;
    
    // Coroutines to stop if change state
    Coroutine showingGhost, hidingGhost;
    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        spriteOpacity = mySprite.color.a;

        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform;
        curState = GhostState.IDLE;
        //StartCoroutine(HideGhost());
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (curState)
        {            
            case GhostState.IDLE:
                // Reset the coroutine that is hiding ghost
                if(hidingGhost != null)
                    StopCoroutine(hidingGhost);
                hidingGhost = null;

                // If showing ghost is null, show ghost
                if (showingGhost == null)
                    showingGhost = StartCoroutine(ShowGhost(showGhostAfter));
                break;
            case GhostState.CHASE:
                if(showingGhost != null)
                    StopCoroutine(showingGhost);
                showingGhost = null;

                if(hidingGhost == null && isActive)
                {
                    hidingGhost = StartCoroutine(HideGhost(hideGhostAfter));
                    StartCoroutine(ShowGhost(showGhostAfter));
                }

                if(isActive)
                    ChasePlayer();
                break;
        }
    }
    
    private void ChasePlayer()
    {
        // Follow player
         transform.position = Vector3.MoveTowards(this.transform.position, GetPlayerPosition(), movementSpeed * Time.deltaTime);
    }

    // Get player position while maintaining Ghost Y pos
    private Vector3 GetPlayerPosition()
    {
        Vector3 temp = Player.position;
        temp.y = this.transform.position.y;
        return temp;
    }

    //
    IEnumerator Cooldown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

    }
    IEnumerator ShowGhost(float waitTime)
    {
        // Wait for x time before showing ghost
        yield return Cooldown(waitTime);
        
        // Increase opacity of sprite renderer
        spriteOpacity = mySprite.color.a;
        while (spriteOpacity < targetOpacity)
        {
            spriteOpacity += appearSpeed;
            mySprite.color = new Color(mySprite.color.r, mySprite.color.g, mySprite.color.b, spriteOpacity);
            yield return new WaitForSeconds(appearSpeed);
        }

        // Set variables
        isActive = true;
        curState = GhostState.CHASE;
    }
    IEnumerator HideGhost(float waitTime)
    {
        // Wait for x time before hiding ghost
        yield return Cooldown(waitTime);

        // Decrease opacity of sprite renderer
        spriteOpacity = mySprite.color.a;
        while (spriteOpacity > 0)
        {
            spriteOpacity -= appearSpeed;
            mySprite.color = new Color(mySprite.color.r, mySprite.color.g, mySprite.color.b, spriteOpacity);
            yield return new WaitForSeconds(appearSpeed);
        }

        // 
        isActive = false;
        //showingGhost = null;
        inContactWithPlayer = false;
        curState = GhostState.IDLE;
    }
  
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        // If in contact with player
        if (collision.name == Player.name && inContactWithPlayer == false && isActive)
        {
            inContactWithPlayer = true;         // Set this bool to true
            StopAllCoroutines();                // Reset all coroutine
            StartCoroutine(HideGhost(0.0f));    // Start to hide ghost with 0 wait time
            curState = GhostState.IDLE;         // Change state to IDLE

        }
    }
}
