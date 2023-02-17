using UnityEngine;

public class PlayerEyesState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I can't see shit");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.animator.SetBool("Eyes", true);

        if (Input.GetKeyUp(KeyCode.LeftShift)) //if no longer pressing
        {
            player.animator.SetBool("Eyes", false);

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
