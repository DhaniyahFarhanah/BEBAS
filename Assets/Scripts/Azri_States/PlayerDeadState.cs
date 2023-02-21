using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Oh he ded");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.spriteRenderer.flipX = false;

            player.SwitchState(player.idleState);


    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
}
