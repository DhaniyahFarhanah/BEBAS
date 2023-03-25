using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    //Script done by Dhaniyah Farhanah Binte Yusoff
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Oh he ded");

    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
}
