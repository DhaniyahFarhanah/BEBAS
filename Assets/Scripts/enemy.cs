using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 0.8f; //variable for enemy speed (default)

    public float range = 3; //variable for enemy range (default)

    float startingX; //starting point

    int direction = 1; //direction where the enemy is headed

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x; //move left and right
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * direction); //for the enemy to start moving 

        if (transform.position.x < startingX || transform.position.x > startingX + range) //if enemy moved to the point outside range, flip it and it goes in the other direction
        {
            direction *= -1; //flip
        }
    }
}
