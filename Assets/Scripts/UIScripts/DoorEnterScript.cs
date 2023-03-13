using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] Transform player;

    [SerializeField] GameObject roomToBeEnabled;

    [SerializeField] bool checkEnter;

    [SerializeField] AudioSource doorOpenSound;

    [SerializeField] GameObject DoorOverlay;

    Animator animator;

    public float x;
    public float y;
    public float z;

    void Awake()
    {
        animator = DoorOverlay.GetComponentInChildren<Animator>();
        if (!playerManager)
        {
            playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            if (!playerManager)
                Debug.LogError("You are missing a PlayerManager GameObject in scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && checkEnter == true)
        {
            doorOpenSound.Play();
            StartCoroutine(DoorView());
            Debug.Log("Enter");
            roomToBeEnabled.SetActive(true);
            playerManager.checkpointX = this.transform.position.x;
            playerManager.checkpointY = this.transform.position.y;
            Debug.Log("This is " + this.gameObject.name);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
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
