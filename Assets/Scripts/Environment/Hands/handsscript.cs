using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handsscript : MonoBehaviour
{
    //Script done by Avian (koko)

    public float speed;
    Vector3 targetPos;

    public GameObject path;
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;
    [SerializeField] float waitTime;

    private bool isWaiting = false;

    private void Awake()
    {
        wayPoints = new Transform[path.transform.childCount];

        for (int i = 0; i < path.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = path.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void Update()
    {
        if (!isWaiting) {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            if (transform.position == targetPos)
            {
                StartCoroutine(Wait());
                NextPoint();
            }
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;  //set the bool to stop moving
        yield return new WaitForSeconds(waitTime); // wait for 3 sec
        isWaiting = false; // set the bool to start moving
    }

    void NextPoint()
    {

        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;

    }
}

