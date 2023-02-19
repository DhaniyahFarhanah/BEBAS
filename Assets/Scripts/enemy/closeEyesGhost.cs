using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeEyesGhost : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "closeEyesGhost") //if the player collides with objects with the tag "ghost"
        {
            PlayerManager.isGameOver = true; //game is over is true
            gameObject.SetActive(false); //destroys the player object 
        }
    }
}


