using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am crouching");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
        if (Input.GetKeyUp(KeyCode.C)) //if no longer pressing
        {
            if (Input.GetAxisRaw("Horizontal") == 0) //idle
            {
                player.SwitchState(player.idleState);
            }
            else
            {
                player.SwitchState(player.walkState);
            }

        }
 

    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
}
