using System.Collections;
using UnityEngine;

public class SecurityGuardMove : MonoBehaviour
{
    public Transform[] patrolPoints;

    public float moveSpeed;

    public int patrolDestination;


    private bool isWaiting = false;

    [SerializeField] private Collider2D myCollider;
    private Transform Player;
    private BoxCollider2D playerCollider;

    private void Start()
    {
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform; if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCollider = Player.gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (!isWaiting)
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    Debug.Log("Go to first waypoint");
                    transform.Rotate(0, -180, 0);
                    patrolDestination = 1;
                    StartCoroutine(Wait());
                    //paceCounter++;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    Debug.Log("Go to second waypoint");
                    transform.Rotate(0, 180, 0);
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
        isWaiting = false; // set the bool to start moving
    }
}
