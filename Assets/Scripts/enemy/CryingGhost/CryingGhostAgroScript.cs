using System.Collections;
using UnityEngine;

public class CryingGhostAgroScript : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] bool FirstSpawn;
    [SerializeField] bool FirstRunIn;
    [SerializeField] Transform player;

    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float agroSpeed;

    [SerializeField] GameObject agroBounds;
    [SerializeField] GameObject panicAfter;
    [SerializeField] GameObject dialogueBox;

    [SerializeField] AudioSource cryingSound;
    [SerializeField] AudioSource agroSound;

    [SerializeField] Animator ghostanimator;

    [SerializeField]
    Transform[] waypoints;
    [SerializeField] int curWayPointIndex;

    [SerializeField] private EventDialogue lorePaperDialogue;
    [SerializeField] private GameObject holdBreathInstruction;
    Rigidbody2D rb2d;
    CheckAgroCryingScript checkAgro;
    BoxCollider2D killer;
    PlayerStateManager playerStateManager;
    SpriteRenderer SpriteRenderer;
    Vector3 originalPos;
    IEnumerator firstSpawnAgro;
    SetJumpscare killedPlayerScript;
    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerStateManager = player.GetComponent<PlayerStateManager>();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        checkAgro = agroBounds.GetComponent<CheckAgroCryingScript>();
        killer = gameObject.GetComponent<BoxCollider2D>();
        originalPos = this.transform.position;
        if (!lorePaperDialogue)
            lorePaperDialogue = GameObject.Find("DialogueForCryingGhost").GetComponent<EventDialogue>();
        if (!holdBreathInstruction)
            holdBreathInstruction = GameObject.Find("HoldBreathInstruction");
    }
    void Start()
    {
        FirstSpawn = true;
        FirstRunIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.activeSelf == false && killedPlayerScript.KilledPlayer)
        {
            Debug.Log("player is dead");
            if(this.transform.position != originalPos)
            {
                this.transform.position = originalPos;
                lorePaperDialogue.dialogueAppearedBefore = false;   // Reset so that dialogue will trigger again
                holdBreathInstruction.SetActive(false);
                StopAllCoroutines();
                FirstSpawn = true;
                FirstRunIn = true;
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            killedPlayerScript.KilledPlayer = false;

            if (FirstSpawn)
            {
                if (!cryingSound.isPlaying)
                {
                    cryingSound.Play();
                }
                firstSpawnAgro = FirstSpawnAgro();
                StartCoroutine(firstSpawnAgro);
            }
            //distance to player
            float dist2player = Vector2.Distance(transform.position, player.transform.position);

            //the amount of conditition is longer than my will to live
            if (dist2player < agroRange && playerStateManager.currentState != playerStateManager.breathState && !checkAgro.justEntered && !FirstSpawn && playerStateManager.currentState != playerStateManager.deadState && !dialogueBox.activeInHierarchy)
            {

                killPlayer();
            }

            else if (!FirstSpawn && !dialogueBox.activeInHierarchy)
            {
                Walk();
            }


            if (FirstRunIn && dist2player > 6.1f)
            {
                panicAfter.SetActive(true);
                FirstRunIn = false;
                killer.enabled = true;
            }
        }

    }

    void killPlayer()
    {

        cryingSound.Stop();
        if (!agroSound.isPlaying)
        {
            agroSound.Play();
        }

        killer.enabled = true;

        ghostanimator.SetBool("isAgro", false);
        //move to player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, agroSpeed * Time.deltaTime);




        //if on left of player, will move right
        if (transform.position.x < player.position.x)
        {
            SpriteRenderer.flipX = true;
            //the below is to make the child walk another direction but idk if that works or no
            //curWayPointIndex = 1;

        }

        //if on right of player, will move left
        else if (transform.position.x > player.position.x)
        {
            SpriteRenderer.flipX = false;
            //curWayPointIndex = 0;

        }

    }

    void Walk()
    {
        agroSound.Stop();
        if (!cryingSound.isPlaying)
        {
            cryingSound.Play();
        }

        ghostanimator.SetBool("isAgro", true);

        killer.enabled = false;

        // Constantly move AI to wayPoints[curWayPointIndex]
        transform.position = Vector2.MoveTowards(transform.position, waypoints[curWayPointIndex].position, moveSpeed * Time.deltaTime);

        // Checks if AI reached waypoint
        if (Vector2.Distance(transform.position, waypoints[curWayPointIndex].position) < .2f)
        {
            // If reached waypoint, increment waypoint index
            curWayPointIndex = (curWayPointIndex + 1) < waypoints.Length ? curWayPointIndex + 1 : 0;
        }

        if (curWayPointIndex == 0)
        {
            if (SpriteRenderer.flipX == true)
            {
                SpriteRenderer.flipX = false;
            }
        }
        else if (curWayPointIndex == 1)
        {
            if (SpriteRenderer.flipX != true)
            {
                SpriteRenderer.flipX = true;
            }
        }
    }

    IEnumerator FirstSpawnAgro()
    {
        killer.enabled = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("You better hold your breath now");


        if (playerStateManager.currentState != playerStateManager.breathState)
        {

            cryingSound.Stop();
            if (!agroSound.isPlaying)
            {
                agroSound.Play();
            }
            yield return new WaitForSeconds(2f);
            killer.enabled = true;
            FirstSpawn = false;
        }
        else
        {
            FirstSpawn = false;
        }
    }
}
