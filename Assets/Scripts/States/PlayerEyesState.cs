using UnityEngine;

public class PlayerEyesState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I can't see shit");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) //if no longer pressing
        {
            if (Input.GetAxisRaw("Horizontal") == 0) //idle
            {
                player.SwitchState(player.idleState);
            }
            else //walk
            {
                player.SwitchState(player.walkState);
            }

        }
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
}
