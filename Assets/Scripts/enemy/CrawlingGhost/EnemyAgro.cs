using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float agroRange;
    [SerializeField] private float movespeed;
    [SerializeField] private float killmovespeed;
    [SerializeField] private float checkpointXset;
    [SerializeField] private float checkpointYset;
    [SerializeField] private float checkpointZset;

    public bool triggerAgro;

    PlayerStateManager playerState;
    CheckAgroRange checkAgroRange;
    PlayerManager setCheckpoint;

    [SerializeField] GameObject playerManager;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject checkAgro;
    [SerializeField] public GameObject playerGO;

    public GameObject[] Waypoints;
    public int[] index; //index for ghost states
    /* 0: crawling
     * 1: backwall
     * 2: ceiling
     * 3: Death
     * 4: idle trigger
    */
    public bool[] flip;

    public SpriteRenderer spriteRenderer;
    
    int nextWayPoint = 0;
    float distToWaypoint;

    Vector3 spawnPoint;

    public Animator anim;
    public Rigidbody2D rb2d;

    private void Awake()
    {
        playerState = player.GetComponent<PlayerStateManager>();
        checkAgroRange = checkAgro.GetComponent<CheckAgroRange>();
        setCheckpoint = playerManager.GetComponent<PlayerManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        triggerAgro = false;
        spawnPoint = gameObject.transform.position;
        anim.SetInteger("Index", 4);
    }

    // Update is called once per frame
    void Update()
    {

        if(checkAgroRange.canAgro == false)
        {
            //gameObject.transform.position = spawnPoint;
        }

        else if (checkAgroRange.canAgro == true)
        {
            float dist2player = Vector2.Distance(transform.position, player.position);
            //Debug.Log("dist2player: " + dist2player);

            if (dist2player < agroRange)
            {
                //code to wake up
                WakeUp();
            }

            /*if(dist2player < 6)
            {
                anim.SetTrigger("Triggered");
            }*/

            if (dist2player < 4)
            {
                StartCoroutine(WaitForCrawl());

            }

            if (triggerAgro == true)
            {
                WalkOnWall();
                KillCheck();
            }

            else
            {

            }
        }
        
    }

    void WakeUp()
    {
        anim.SetTrigger("Spawn");
    }

    void WalkOnWall()
    {
        CheckWall();
    }

    void CheckWall()
    {
        distToWaypoint = Vector2.Distance(transform.position, Waypoints[nextWayPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[nextWayPoint].transform.position, movespeed * Time.deltaTime);


        if (distToWaypoint < 0.25)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += Waypoints[nextWayPoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;

        ChooseNextWayPoint();
    }

    void ChooseNextWayPoint()
    {
        nextWayPoint++;

        if (nextWayPoint == Waypoints.Length)
        {
            nextWayPoint = 0;
        }

        anim.SetInteger("Index", index[nextWayPoint]);
        spriteRenderer.flipX = flip[nextWayPoint];

        if (index[nextWayPoint] == 1)
        {
            spriteRenderer.sortingLayerName = "Interactable Items";
        }
        else
        {
            spriteRenderer.sortingLayerName = "Player";
        }
    }

    void KillCheck()
    {
        if(playerState.currentState != playerState.eyesState)
        {
            Debug.Log("Kill time");


            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, killmovespeed * agroRange * Time.deltaTime);

            playerState.SwitchState(playerState.deadState);

            gameOver.SetActive(true);

            setCheckpoint.checkpointX = checkpointXset;
            setCheckpoint.checkpointY = checkpointYset;
            setCheckpoint.checkpointZ = checkpointZset;
            

        }
        else
        {
            Debug.Log("Safe");
        }
    }

    IEnumerator WaitForCrawl()
    {
        anim.SetTrigger("Agro");
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("Index", 0);
        triggerAgro = true;
        
    }


}
