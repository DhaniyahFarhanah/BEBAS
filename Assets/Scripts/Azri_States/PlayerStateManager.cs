using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerBaseState currentState;

    //float playerScale;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D playerRB;
    public CapsuleCollider2D standingCollider;
    public BoxCollider2D crouchCollider;

    public GameObject darkness;
    public GameObject dialogueBox;
    public GameObject loreOverlay;
    public GameObject gameOverScreen;

    public PlayerManager PManager;

    public float charSpeed;
    public float dirX;
    public float input;

    public Animator animator;

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
    public PlayerDeadState deadState = new PlayerDeadState();

    //internal PlayerBaseState yeetState;
    //internal PlayerBaseState twerkState;
    //internal PlayerBaseState killState;

    public Image timerBar;
    public float maxTime = 1f;
    float remainingTime;

    public bool isTalking;
    public bool isRun;
    public bool isDead;

    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
        timerBar = GetComponentInChildren<Image>();
        timerBar.enabled = false;
        remainingTime = maxTime;
        isRun = false;
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogueBox.activeInHierarchy || loreOverlay.activeInHierarchy)
        {
            isTalking = true;

            if(currentState == crouchState)
            {
                SwitchState(crouchState);
                
            }
            else if(currentState == eyesState)
            {
                SwitchState(eyesState);
            }
            else if(currentState == breathState)
            {
                SwitchState(breathState);
            }
            else
            {
                SwitchState(idleState);
            }

            animator.SetBool("Idle", true);
            animator.SetBool("Moving", false);
            animator.SetFloat("Speed", 0);

        }
        // =============Player Movement (flip & speed) ================
        else if(!dialogueBox.activeInHierarchy || !loreOverlay.activeInHierarchy)
        {
            isTalking = false;

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
            animator.SetFloat("Speed", Math.Abs(input));

        }

        //=========BREATH BAR===========

        if (remainingTime > 0 && Input.GetKey(KeyCode.Space))
        {
            timerBar.enabled = true;
            remainingTime -= Time.deltaTime;
            Debug.Log(remainingTime);
            timerBar.fillAmount = remainingTime / maxTime;
        }

        if (remainingTime > 0 && remainingTime < 10 && Input.GetKey(KeyCode.Space) == false)
        {
            remainingTime += Time.deltaTime;
            Debug.Log($"{remainingTime}");
            timerBar.enabled = false;
            timerBar.fillAmount = maxTime;
        }

        else if (remainingTime <= 0 && Input.GetKey(KeyCode.Space))
        {
            timerBar.enabled = false;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }

    }

    void FixedUpdate() //set to run 50 frames per second
    {
        playerRB.velocity = new Vector2(input * charSpeed, playerRB.velocity.y);

    }

    //============STATE PROPERTIES HERE=================
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;

        switch (currentState)
        {
            case PlayerWalkState:
                //anim states
                // animator.SetBool("Idle", false);
                // animator.SetBool("Moving", true);
                // animator.SetBool("Crouch", false);
                // animator.SetBool("Breath", false);


                //code
                darkness.SetActive(false);
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                spriteRenderer.sprite = walking;
                animator.SetBool("isRun", isRun);
                
                if (isRun)
                {
                    charSpeed = 9f;
                }
                else
                {
                    charSpeed = 4.5f;
                }
                break;

            case PlayerCrouchState:
                //anim states
               

                //code
                darkness.SetActive(false);
                crouchCollider.enabled = true;
                standingCollider.enabled = false;
                spriteRenderer.sprite = crouch;

                if (isTalking)
                {
                    charSpeed = 0f;
                }

                else
                {
                    charSpeed = 3f;
                }


                break;

            case PlayerHoldBreathState:
                //anim states

                //code
                darkness.SetActive(false);
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                spriteRenderer.sprite = breath;

                if (isTalking)
                {
                    charSpeed = 0f;
                }

                else
                {
                    charSpeed = 2f;
                }

                break;

            case PlayerEyesState:
                //anim states

                //code
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                spriteRenderer.sprite = closedEyes;

                if (isTalking)
                {
                    charSpeed = 0f;
                    darkness.SetActive(false);

                }

                else
                {
                    charSpeed = 2f;
                    darkness.SetActive(true);
                }

                break;

            case PlayerIdleState:
                //anim states
                //code
                darkness.SetActive(false);
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                spriteRenderer.sprite = idle;
                charSpeed = 0f;
                break;

            case PlayerDeadState:
                darkness.SetActive(false);
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                break;


        }

        state.EnterState(this);
    }
}
