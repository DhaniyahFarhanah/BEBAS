using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
    public Transform player;

    EnemyAgro crawlingGhost;

    public GameObject ghost;

    public float x;
    public float y;
    public float z;

    void Awake()
    {
        crawlingGhost = ghost.GetComponent<EnemyAgro>();    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                player.position = new Vector3(x, y, z);
                crawlingGhost.triggerAgro = false;
                
                Debug.Log("Enter");
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                player.position = new Vector3(x, y, z);
                Debug.Log("Enter");
            }
            
        }
    }

}
