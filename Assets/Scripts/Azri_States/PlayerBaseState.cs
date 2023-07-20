using System;
using UnityEngine;

//Script done by Dhaniyah Farhanah Binte Yusoff
public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager player);
   

    public abstract void UpdateState(PlayerStateManager player);
    

    public abstract void OnCollisionEnter(PlayerStateManager player);

}
