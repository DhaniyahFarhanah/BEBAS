using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am walking");
        player.walkingSound.Play();
        player.animator.SetBool("Moving", true);

    }

    public override void UpdateState(PlayerStateManager player)
    {

        player.animator.SetBool("Moving", true);
        

        if (Input.GetKey(KeyCode.Space)) //Holding Breath
       {
            player.animator.SetBool("Moving", false);

            player.SwitchState(player.breathState);
       }
       if (Input.GetKeyDown(KeyCode.S)) //Crouching
       {
            player.animator.SetBool("Moving", false);

            player.SwitchState(player.crouchState);
       }
       if (Input.GetKeyDown(KeyCode.LeftShift)) //covering eyes
       {
            player.animator.SetBool("Moving", false);

            player.SwitchState(player.eyesState);
       }

        if (Input.GetAxisRaw("Horizontal") == 0) //idle
        {
            player.animator.SetBool("Moving", false);

            player.SwitchState(player.idleState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }

}
