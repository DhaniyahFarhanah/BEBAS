using UnityEngine;

/// <summary>
/// This script will be attached to CryingGhost in Ward room
/// </summary>
public class CryingGhostManager : MonoBehaviour
{
    private enum GhostState { IDLE, MOVING };
    private GhostState curState = GhostState.IDLE;

    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private int curWayPointIndex;

    [Range(1, 10)]
    [SerializeField] private float moveSpeed = 4.0f;


    private void Start()
    {
        if (moveSpeed == 0.0f)
            moveSpeed = 4.0f;
    }
    // Update is called once per frame
    void Update()
    {
        handleAIState();
    }

    private void handleAIState()
    {
        switch (curState)
        {
            case GhostState.IDLE:
                handleIdle();
                break;
            case GhostState.MOVING:
                handleMovement();
                break;
            default:
                break;
        }
    }

    // Not sure if needed or not, making states just in case
    private void handleIdle()
    {
        // Animations?
        // What triggers other state?

        // Go to MOVING state
        curState = GhostState.MOVING;
    }

    // Move from waypoint to waypoint
    private void handleMovement()
    {
        // Constantly move AI to wayPoints[curWayPointIndex]
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[curWayPointIndex].position, moveSpeed * Time.deltaTime);

        // Checks if AI reached waypoint
        if (Vector2.Distance(transform.position, wayPoints[curWayPointIndex].position) < .2f)
        {
            // If reached waypoint, increment waypoint index
            curWayPointIndex = (curWayPointIndex + 1) < wayPoints.Length ? curWayPointIndex+1 : 0;
        }
        
    }
}
