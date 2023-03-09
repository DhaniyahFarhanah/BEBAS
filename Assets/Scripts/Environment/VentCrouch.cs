using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCrouch : MonoBehaviour
{
    [SerializeField] GameObject player;

    PlayerStateManager state;

    private void Awake()
    {
        state = player.GetComponent<PlayerStateManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        state.isInVent = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        state.isInVent = false;
        if(state.input > 0 || state.input < 0)
        {
            state.animator.SetBool("Crouch", false);
            state.SwitchState(state.walkState);

        }
        else if(state.input == 0)
        {
            state.animator.SetBool("Crouch", false);
            state.SwitchState(state.idleState);
        }
    }


}
