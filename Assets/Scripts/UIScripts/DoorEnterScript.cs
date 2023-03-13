using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && checkEnter == true)
        {
            doorOpenSound.Play();
            StartCoroutine(DoorView());
            Debug.Log("Enter");
            roomToBeEnabled.SetActive(true);
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
