using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;

    public Sprite idle;
    public Sprite walking;
    public Sprite closedEyes;
    public Sprite breath;
    public Sprite crouch;

    
    public float speed = 8f;
    public float dirX;
    public float input;
    
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody= GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        Debug.Log("Started");

        spriteRenderer.sprite = idle;
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.V))
        {
            speed = 3f;
            spriteRenderer.sprite = breath;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            speed = 2f;
            spriteRenderer.sprite = crouch;
        }

        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1f;
            spriteRenderer.sprite = breath;
 
        }

        else {
            speed = 6f;
            spriteRenderer.sprite = idle;
        }

  

        if (input < 0)
        {
            spriteRenderer.flipX = true; 
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }

    }
    void FixedUpdate() //set to run 50 frames per second
    {
        playerRigidBody.velocity = new Vector2(input * speed, playerRigidBody.velocity.y);
        
    }
}
