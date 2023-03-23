using JetBrains.Annotations;
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
    public GameObject npcDialogue;
    public GameObject checkWard;


    public PlayerManager PManager;

    public float charSpeed;
    public float dirX;
    public float input;

    public Animator animator;

    //audio
    public AudioClip runAudio;
    public AudioClip OutdoorWalkClip;
    public AudioClip IndoorWalkClip;
    public AudioClip crouchSoundClip;
    public AudioClip fastPant;

    public AudioSource walkingSound;
    public AudioSource closeEyesAmbience;
    public AudioSource breathingSound;
    public AudioSource outofbreathSound;
    public AudioSource recoveringbreathSound;
    public AudioSource heartbeatSound;

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

    public Image timerBar;
    public float maxTime = 1f;
    public float remainingTime;

    public bool isTalking;
    public bool isRun;
    public bool isDead;
    public bool isInVent;

    CheckAgroCryingScript checkAgroCryingScript;


    private void Awake()
    {
        checkAgroCryingScript = checkWard.GetComponent<CheckAgroCryingScript>();
    }

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
       
        //if walking, play walking sound
        if(charSpeed > 0)
        {
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
        }
        else
        {
            walkingSound.Stop();
        }

        if (dialogueBox.activeInHierarchy || loreOverlay.activeInHierarchy || npcDialogue.activeInHierarchy)
        {
            isTalking = true;

            if(currentState == crouchState)
            {
                SwitchState(crouchState);
                
            }
            else if(currentState == eyesState)
            {
                SwitchState(eyesState);
                darkness.SetActive(true);
            }

            else if(currentState == breathState)
            {
                SwitchState(breathState);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    SwitchState(idleState);
                    animator.SetBool("Breath", false);
                }
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
        else if(!dialogueBox.activeInHierarchy || !loreOverlay.activeInHierarchy || !npcDialogue.activeInHierarchy)
        {
            isTalking = false;

            input = Input.GetAxisRaw("Horizontal");

            if (input < 0 && currentState != deadState)
            {
                
                spriteRenderer.flipX = true;
            }
            else if (input > 0 && currentState != deadState)
            {
               

                spriteRenderer.flipX = false;
            }
            currentState.UpdateState(this);
            animator.SetFloat("Speed", Math.Abs(input));

        }

        

        //=========BREATH BAR===========

        if(remainingTime < 3f)
        {
            timerBar.color = new Color(255, 0, 0);
            if (!outofbreathSound.isPlaying)
            {
                outofbreathSound.Play();
            }

            if (breathingSound.isPlaying)
            {
                breathingSound.Stop();
            }

        }
        else
        {
            timerBar.color = new Color(255, 255, 255);
            outofbreathSound.Stop();
            

        }

        if (remainingTime > 0 && Input.GetKey(KeyCode.Space) && currentState == breathState)
        {
            timerBar.enabled = true;
            remainingTime -= Time.deltaTime;
            Debug.Log(remainingTime);
            timerBar.fillAmount = remainingTime / maxTime;
        }

        if (remainingTime > 0 && remainingTime < 10 && Input.GetKey(KeyCode.Space) == false)
        {
            remainingTime += Time.deltaTime;
            timerBar.enabled = false;
            timerBar.fillAmount = maxTime;
        }

        

        else if (remainingTime <= 0 && Input.GetKey(KeyCode.Space) && currentState == breathState)
        {
            timerBar.enabled = false;
            remainingTime += Time.deltaTime;
            animator.SetBool("Breath", false);
            if (charSpeed == 0)
            {
                currentState = idleState;
                SwitchState(idleState);

            }
            else if (charSpeed > 0)
            {
                currentState = walkState;
                SwitchState(walkState);
            }
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

                //if (stopAudioSource)
                //{
                //    audioSource.Stop();
                //}
                //audioSource.PlayOneShot(walkingSoundClip);
                //audio
                closeEyesAmbience.Stop();
                heartbeatSound.Stop();

                //code
                darkness.SetActive(false);
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                spriteRenderer.sprite = walking;
                animator.SetBool("isRun", isRun);
                
                if (isRun)
                {
                    breathingSound.clip = fastPant;
                    breathingSound.Play();
                    charSpeed = 12f;
                    walkingSound.clip = runAudio;
                }
                else
                {
                    if (checkAgroCryingScript.inWard)
                    {
                        walkingSound.clip = IndoorWalkClip;
                    }
                    else
                    {
                        walkingSound.clip = OutdoorWalkClip;
                    }
                    breathingSound.Stop();
                    charSpeed = 4.5f;
                }
                break;

            case PlayerCrouchState:
                //audio
                closeEyesAmbience.Stop();
                heartbeatSound.Stop();
                breathingSound.Stop();

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
                    //walkingSound.clip = crouchSoundClip;
                }


                break;

            case PlayerHoldBreathState:
                //audio
                closeEyesAmbience.Stop();
                heartbeatSound.Stop();
                breathingSound.Play();
                

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
                //audio
                closeEyesAmbience.Play();
                heartbeatSound.Play();
                breathingSound.Play();


                //code
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                spriteRenderer.sprite = closedEyes;

                if (isTalking)
                {
                    charSpeed = 0f;


                }

                else
                {
                    charSpeed = 2f;
                    darkness.SetActive(true);
                }

                break;

            case PlayerIdleState:
                //anim states
                //audio
                closeEyesAmbience.Stop();
                heartbeatSound.Stop();
                breathingSound.Stop();

                darkness.SetActive(false);
                crouchCollider.enabled = false;
                standingCollider.enabled = true;
                spriteRenderer.sprite = idle;
                charSpeed = 0f;
                break;

            case PlayerDeadState:
                //audio
                closeEyesAmbience.Stop();
                heartbeatSound.Stop();
                breathingSound.Stop();
                walkingSound.Stop();

                darkness.SetActive(false);
                crouchCollider.enabled = false;
                standingCollider.enabled = false;
                break;


        }

        state.EnterState(this);
    }
}
