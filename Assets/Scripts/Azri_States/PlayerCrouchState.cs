using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    //Script done by Dhaniyah Farhanah Binte Yusoff
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am crouching");
        if (player.input != 0)
        {
            player.walkingSound.Play();
        }
        else
        {
            player.walkingSound.Stop();
        }

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

        if (player.input == 0)
        {
            player.walkingSound.Stop();
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
