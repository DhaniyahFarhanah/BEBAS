using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I am walking");
    }

    public override void UpdateState(PlayerStateManager player)
    {
       if (Input.GetKey(KeyCode.X)) //Holding Breath
       {
           player.SwitchState(player.breathState);
       }
       if (Input.GetKeyDown(KeyCode.C)) //Crouching
       {
            player.SwitchState(player.crouchState);
       }
       if (Input.GetKeyDown(KeyCode.LeftShift)) //covering eyes
       {
           player.SwitchState(player.eyesState);
       }

        if (Input.GetAxisRaw("Horizontal") == 0) //idle
        {
            player.SwitchState(player.idleState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }

}
