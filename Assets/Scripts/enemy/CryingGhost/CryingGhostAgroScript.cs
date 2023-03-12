using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingGhostAgroScript : MonoBehaviour
{

    [SerializeField] bool FirstSpawn;
    [SerializeField] bool FirstRunIn;
    [SerializeField] Transform player;

    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float agroSpeed;

    [SerializeField] GameObject agroBounds;
    [SerializeField] GameObject panicAfter;

    [SerializeField]
    Transform[] waypoints;
    [SerializeField] int curWayPointIndex;

    Rigidbody2D rb2d;
    CheckAgroRange checkAgro;
    BoxCollider2D killer;
    PlayerStateManager playerStateManager;
    SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerStateManager = player.GetComponent<PlayerStateManager>();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        checkAgro = agroBounds.GetComponent<CheckAgroRange>();
        killer = gameObject.GetComponent<BoxCollider2D>();

    }
    void Start()
    {
        FirstSpawn = true;
        FirstRunIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstSpawn)
        {
            StartCoroutine(FirstSpawnAgro());
        }
        //distance to player
        float dist2player = Vector2.Distance(transform.position, player.transform.position);

        //the amount of conditition is longer than my will to live
        if(dist2player < agroRange && playerStateManager.currentState != playerStateManager.breathState && checkAgro.canAgro && checkAgro.noImmediateKill && !FirstSpawn &&  playerStateManager.currentState != playerStateManager.deadState)
        {
            if (!killer.isActiveAndEnabled)
            {
                killer.enabled = true;
            }

            killPlayer();
        }

        else if (!FirstSpawn)
        {
            Walk();
        }

        if (!checkAgro.noImmediateKill)
        {
            killer.enabled = false;
        }

        if(FirstRunIn && dist2player > 6.1f)
        {
            panicAfter.SetActive(true);
            FirstRunIn = false;
            killer.enabled = true;
        }


    }

    void killPlayer()
    {
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
        killer.enabled = true;
        // Constantly move AI to wayPoints[curWayPointIndex]
        transform.position = Vector2.MoveTowards(transform.position, waypoints[curWayPointIndex].position, moveSpeed * Time.deltaTime);

        // Checks if AI reached waypoint
        if (Vector2.Distance(transform.position, waypoints[curWayPointIndex].position) < .2f)
        {
            // If reached waypoint, increment waypoint index
            curWayPointIndex = (curWayPointIndex + 1) < waypoints.Length ? curWayPointIndex + 1 : 0;
        }
    }

    IEnumerator FirstSpawnAgro()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("You better hold your breath now");


        if(playerStateManager.currentState != playerStateManager.breathState)
        {
            yield return new WaitForSeconds(1f);
            killer.enabled = true;
            killPlayer();
            FirstSpawn = false;
        }
        else
        {
            
            FirstSpawn = false;
        }
    }
}