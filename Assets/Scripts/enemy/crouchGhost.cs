using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchGhost : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "crouchGhost" && Input.GetKey(KeyCode.S) == true) //if the player collides with objects with the tag "ghost"
        {
            PlayerManager.isGameOver = false; //game is over is true
        }

        else if (collision.transform.tag == "crouchGhost" && Input.GetKey(KeyCode.S) == false)
        {
            PlayerManager.isGameOver = true; //game is over is true
            gameObject.SetActive(false); //destroys the player object 
        }
    }
}
