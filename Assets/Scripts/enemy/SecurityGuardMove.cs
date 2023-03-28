using System.Collections;
using UnityEngine;

public class SecurityGuardMove : MonoBehaviour
{
    //Script done by Avian (koko)
    //Script modified by Stella
    //Script modified by Dhaniyah Farhanah Binte Yusoffs

    public Transform[] patrolPoints;

    public float moveSpeed;

    public int patrolDestination;
    public bool reachedclue;

    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] AudioSource walking;
    [SerializeField] GameObject dialogue;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject deathScreen;

    public Animator animator;
    Rigidbody rb;

    
    public bool isWaiting = false;

    [SerializeField] private Collider2D myCollider;
    private Transform Player;
    private BoxCollider2D playerCollider;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform; if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCollider = Player.gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {

        if (reachedclue && trigger.activeInHierarchy)
        {
            isWaiting = true;
        }
        else if (reachedclue && !trigger.activeInHierarchy)
        {
            reachedclue = false;
            isWaiting = false;
        }
        
        

        if (isWaiting)
        {
            animator.SetBool("isWalking", false);
            walking.Stop();
        }

        if (!isWaiting)
        {
            if (!walking.isPlaying)
            {
                walking.Play();
            }

            animator.SetBool("isWalking", true);

            if (patrolDestination == 0 && !deathScreen.activeInHierarchy)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    Debug.Log("Go to first waypoint");
                    patrolDestination = 1;
                    StartCoroutine(Wait());
                    //paceCounter++;
                }
            }

            if (patrolDestination == 1 && !deathScreen.activeInHierarchy)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    Debug.Log("Go to second waypoint");
                    patrolDestination = 0;
                    StartCoroutine(Wait());
                    //paceCounter++;
                }
            }
        }
        //if (paceCounter >= 12)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
        //    if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
        //    {
        //        transform.localScale = new Vector3(3, 3, 3);
        //        patrolDestination = 2;
        //    }
        //}
    }

    IEnumerator Wait()
    {
        isWaiting = true;  //set the bool to stop moving
        yield return new WaitForSeconds(3); // wait for 3 sec
        transform.Rotate(0, 180, 0);
        isWaiting = false; // set the bool to start moving
    }
}
