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

        if (player.isTalking)
        {
            player.charSpeed = 0f;
        }

        else
        {
            if (player.isRun)
            {
                player.charSpeed = 5f;
            }
            else
            {
                player.charSpeed = 3f;
            }
        }

        if (!player.isInVent)
        {
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

        }


       

    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
}
