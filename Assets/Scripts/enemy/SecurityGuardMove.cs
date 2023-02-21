using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuardMove : MonoBehaviour
{
    public Transform[] patrolPoints;

    public float moveSpeed;

    public int patrolDestination;

    int paceCounter = 0;

    void Update()
    {

            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(3, 3, 3);
                    patrolDestination = 1;
                    paceCounter++;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-3, 3, 3);
                    patrolDestination = 0;
                    paceCounter++;
                }
            }

            if (paceCounter >= 16)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[2].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(3, 3, 3);
                    patrolDestination = 2;
                }
        }
    }

}
