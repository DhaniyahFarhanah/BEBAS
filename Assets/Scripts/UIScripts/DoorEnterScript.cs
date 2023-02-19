using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnterScript : MonoBehaviour
{
    public Transform player;

    public float x;
    public float y;
    public float z;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Can enter");

            if (Input.GetKey(KeyCode.W))
            {
                player.position = new Vector3(x, y, z);
                Debug.Log("Enter");
            }
            
        }
    }

}
