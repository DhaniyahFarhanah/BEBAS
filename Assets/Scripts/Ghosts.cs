using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5.0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = Vector3.Lerp(transform.position, player.position, followSpeed * Time.deltaTime);
        }
    }
}
