using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject DialogueBox;
    [SerializeField] GameObject player;
    [SerializeField] GameObject AgroInWard;

    [SerializeField] bool isWaiting;
    public bool AzriInWard;
    public bool isKilled;

    Animator animator;
    Transform playerTransform;
    Rigidbody2D rb;
    BoxCollider2D killSensor;


    private Vector3 startPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        killSensor = gameObject.GetComponent<BoxCollider2D>();
        playerTransform = player.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
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
    }
    // Update is called once per frame
    void Update()
    {
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
            StopAllCoroutines();
        }
       
    }

    void ChasePlayer()
    {
        Debug.Log("move damn it");
        animator.SetInteger("Status", 2);
        rb.velocity = new Vector2(-moveSpeed, 0);

        if (DialogueBox.activeInHierarchy)
        {
            rb.velocity = Vector2.zero;
        }
        else if (!DialogueBox.activeInHierarchy)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }

        if (transform.position.x == playerTransform.position.x)
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
    }

    
}
