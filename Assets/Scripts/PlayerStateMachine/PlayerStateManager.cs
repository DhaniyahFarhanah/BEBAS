using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D playerRB;
    public GameObject dialogueBox;

    public float charSpeed;
    public float dirX;
    public float input;


    public Sprite idle;
    public Sprite walking;
    public Sprite closedEyes;
    public Sprite breath;
    public Sprite crouch;

    public PlayerWalkState walkState = new PlayerWalkState();
    public PlayerCrouchState crouchState = new PlayerCrouchState();
    public PlayerHoldBreathState breathState = new PlayerHoldBreathState();
    public PlayerEyesState eyesState = new PlayerEyesState();
    public PlayerIdleState idleState = new PlayerIdleState();

    internal PlayerBaseState yeetState;
    internal PlayerBaseState twerkState;
    internal PlayerBaseState killState;

    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            charSpeed = 0f;
    
        }

        else
        {
            input = Input.GetAxisRaw("Horizontal");

            if (input < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (input > 0)
            {
                spriteRenderer.flipX = false;
            }
            currentState.UpdateState(this);

        }

    }

    void FixedUpdate() //set to run 50 frames per second
    {
        playerRB.velocity = new Vector2(input * charSpeed, playerRB.velocity.y);

    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;

        switch (currentState)
        {
                case PlayerWalkState:
                spriteRenderer.sprite = walking;
                charSpeed = 15f;
                break;

                case PlayerCrouchState:
                spriteRenderer.sprite = crouch;
                charSpeed = 3f;
                break;

                case PlayerHoldBreathState:
                spriteRenderer.sprite = breath;
                charSpeed = 2f;
                break;

                case PlayerEyesState:
                spriteRenderer.sprite = closedEyes;
                charSpeed = 1f;
                break;

                case PlayerIdleState:
                spriteRenderer.sprite = idle;
                charSpeed = 0f;
                break;
               

        }

        state.EnterState(this);
    }
}
