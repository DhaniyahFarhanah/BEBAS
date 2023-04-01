using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff
    //Script modified by Stella 

    [SerializeField] float moveSpeed;
    [SerializeField] GameObject DialogueBox;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject player;
    [SerializeField] GameObject AgroInWard;

    [SerializeField] bool isWaiting;
    [SerializeField] AudioSource shacklesound;
    [SerializeField] AudioSource rawrXD;
    public float timeToWaitAfterRespawn;
    public bool AzriInWard;
    public bool isKilled;

    Animator animator;
    Transform playerTransform;
    Rigidbody2D rb;
    BoxCollider2D killSensor;
    PlayerStateManager state;


    private Vector3 startPos;
    private bool respawning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        killSensor = gameObject.GetComponent<BoxCollider2D>();
        playerTransform = player.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        state = player.GetComponent<PlayerStateManager>();
    }
    void Start()
    {
        rawrXD.Play();
        isWaiting = true;
        AzriInWard = false;
        startPos = transform.position;
        //subscribes to the restart event when the player restarts to the nearest checkpoint
        PlayerManager.RestartAtCheckPoint += ResetGhost;

    }
    private void OnDestroy()
    {
        //unsubscribes to the event
        PlayerManager.RestartAtCheckPoint -= ResetGhost;
    }
    private void ResetGhost()
    {
        transform.position = startPos;
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        respawning = true;
        yield return new WaitForSeconds(timeToWaitAfterRespawn);
        respawning = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (respawning) return;
        if(rb.velocity == new Vector2(-moveSpeed, 0))
        {
            if (!shacklesound.isPlaying)
            {
                shacklesound.Play();
            }
        }
        
        else
        {
            shacklesound.Stop();
        }

        if (isWaiting)
        {
            killSensor.enabled = false;
        }
        else
        {
            killSensor.enabled = true;
        }

        if (!DialogueBox.activeInHierarchy && isWaiting)
        {

            StartCoroutine(WaitForAgro());
        }
        else
        {
            ChasePlayer();
        }

        if (AzriInWard)
        {
            //spawn in ward
            AgroInWard.SetActive(true);
            gameObject.IsDestroyed();

        }

        

        if (isKilled)
        {
            //StopAllCoroutines();
            isWaiting = true;
        }
       
    }

    void ChasePlayer()
    {
        Debug.Log("move damn it");
        animator.SetInteger("Status", 2);
        rb.velocity = new Vector2(-moveSpeed, 0);

        if (DialogueBox.activeInHierarchy || GameOver.activeInHierarchy)
        {
            rb.velocity = Vector2.zero;
        }
        else if (!DialogueBox.activeInHierarchy)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }

        if (state.currentState == state.deadState)
        {
            isKilled = true;
            rb.velocity = Vector2.zero;
        }
        
    }

    IEnumerator WaitForAgro()
    {
        animator.SetInteger("Status", 1);
        yield return new WaitForSeconds(2f);
        //play anim of revival here
        ChasePlayer();
        isWaiting = false;
        isKilled = false;
    }

    
}
