using UnityEngine;

public class playercollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ghost") //if the player collides with objects with the tag "ghost"
        {
            PlayerManager.isGameOver = true; //game is over is true
            gameObject.SetActive(false); //destroys the player object 
        }
    }
} 