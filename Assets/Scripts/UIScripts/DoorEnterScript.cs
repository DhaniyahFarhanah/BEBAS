using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] GameObject roomToBeEnabled;

    [SerializeField] bool checkEnter;

    [SerializeField] AudioSource doorOpenSound;

    public float x;
    public float y;
    public float z;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && checkEnter == true)
        {
            doorOpenSound.Play();
            player.position = new Vector3(x, y, z);
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


}
