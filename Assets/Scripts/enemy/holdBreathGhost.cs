using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdBreathGhost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "holdBreathGhost" && Input.GetKey(KeyCode.Space) == true) //if the player collides with objects with the tag "ghost"
        {
            PlayerManager.isGameOver = false; //game is over is true
        }

        else if (collision.transform.tag == "holdBreathGhost" && Input.GetKey(KeyCode.Space) == false)
        {
            PlayerManager.isGameOver = true; //game is over is true
            gameObject.SetActive(false); //destroys the player object 
        }
    }
}
