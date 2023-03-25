using UnityEngine;

public class PlayerHoldBreathState : PlayerBaseState
{
    //Script done by Dhaniyah Farhanah Binte Yusoff
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I can't breath");
       
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.animator.SetBool("Breath", true);

        if (player.isTalking)
        {
            player.charSpeed = 0f;

        }

        else
        {
            player.charSpeed = 2f;
        }

       if(player.input == 0)
        {
            player.walkingSound.Stop();
        }

       
        

        if (Input.GetKeyUp(KeyCode.Space)) //if no longer pressing
        {
            player.animator.SetBool("Breath", false);

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
