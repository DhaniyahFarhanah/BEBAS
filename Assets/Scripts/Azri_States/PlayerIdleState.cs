using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    SpriteRenderer spriteRender;

    public Rigidbody2D playerRB;

    public override void EnterState(PlayerStateManager player)
    {

        Debug.Log("Ayo I'm standing still");
        player.animator.SetBool("Idle", true);
        player.animator.SetBool("Moving", false);
        player.animator.SetFloat("Speed", 0);

    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.animator.SetBool("Idle", true);

        if (Input.GetKeyDown(KeyCode.Space)) //Holding Breath
        {
            player.animator.SetBool("Idle", false);

            player.SwitchState(player.breathState);
        }
        if (Input.GetKeyDown(KeyCode.S)) //Crouching
        {
            player.animator.SetBool("Idle", false);

            player.SwitchState(player.crouchState);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) //covering eyes
        {
            player.animator.SetBool("Idle", false);

            player.SwitchState(player.eyesState);
        }

        if (Input.GetAxisRaw("Horizontal") != 0) //not idle
        {
            player.animator.SetBool("Idle", false);

            player.SwitchState(player.walkState);
        }
    }

    public override void OnCollisionEnter(PlayerStateManager player)
    {

    }
}
