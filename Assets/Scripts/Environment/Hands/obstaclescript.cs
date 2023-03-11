using UnityEngine;

public class obstaclescript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle") //if the player collides with objects with the tag "obstacle"
        {
            Debug.Log("Skill issue");
            PlayerManager.isGameOver = true; //game is over is true
            gameObject.SetActive(false); //destroys the player object 
        }
    }
}