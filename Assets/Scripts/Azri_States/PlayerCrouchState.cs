using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am crouching");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.animator.SetBool("Crouch", true);

        if (Input.GetKeyUp(KeyCode.S)) //if no longer pressing
        {
            player.animator.SetBool("Crouch", false);

            if (Input.GetAxisRaw("Horizontal") == 0) //idle
            {
                player.SwitchState(player.idleState);
            }
            else
            {
                player.SwitchState(player.walkState);
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.animator.SetBool("Crouch", false);

            player.SwitchState(player.eyesState);
        }


    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
}
