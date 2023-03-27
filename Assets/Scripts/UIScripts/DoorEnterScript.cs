using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorEnterScript : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] GameObject playerScripts;

    [SerializeField] GameObject roomToBeEnabled;

    [SerializeField] bool checkEnter;
    [SerializeField] bool endGame;

    [SerializeField] AudioSource doorOpenSound;
    [SerializeField] AudioSource doorCloseSound;
    [SerializeField] AudioSource doorSound;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite opendoor;
    [SerializeField] Sprite closeDoor;

    [SerializeField] GameObject DoorOverlay;

    PlayerStateManager playerTalking;
    Animator animator;
    Transform player;


    public float x;
    public float y;
    public float z;


    public static event Action EnteredWard;
    void Awake()
    {
        animator = DoorOverlay.GetComponentInChildren<Animator>();
        if (!playerManager)
        {
            playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            if (!playerManager)
                Debug.LogError("You are missing a PlayerManager GameObject in scene.");
        }

        playerTalking = playerScripts.GetComponent<PlayerStateManager>();
        player = playerScripts.GetComponent<Transform>();

    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W) && checkEnter == true && !playerTalking.isTalking)
        {
            if (endGame)
            {
                //change scene
                doorOpenSound.Play();
                StateManager.Instance.SwitchSceneTo("EndGameScene");

            }
            else
            {
                doorOpenSound.Play();
                StartCoroutine(DoorView());
                Debug.Log("Enter");
                roomToBeEnabled.SetActive(true);
                EnteredWard?.Invoke();
                playerManager.checkpointX = player.transform.position.x;
                playerManager.checkpointY = player.transform.position.y;
                Debug.Log("This is " + this.gameObject.name);

            }
        }

        if (checkEnter)
        {
            sr.sprite = opendoor;
            
        }
        else
        {
            sr.sprite = closeDoor;
            doorSound.Stop();
            
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (this.isActiveAndEnabled)
            {
                doorSound.Play();
            }

            checkEnter = true;
            

        }
        else
        {
            checkEnter = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            checkEnter = true;
            
        }
        else
        {
            checkEnter = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.isActiveAndEnabled)
            {
                doorCloseSound.Play();
            }

            checkEnter = false;
            
        }
    }

    IEnumerator DoorView()
    {
        DoorOverlay.SetActive(true);
        animator.SetBool("Door", true);
        yield return new WaitForSeconds(0.3f);
        player.position = new Vector3(x, y, z);
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("Door", false);
        DoorOverlay.SetActive(false);
    }

}
