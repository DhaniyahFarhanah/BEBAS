using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float horizontal; //for horizontal input
    private float speed = 8f; //speed of the player
    private bool isFacingRight = true; //check of player is facing right or left

    //serialised fields are needed to ref in unity

    [SerializeField] private Rigidbody2D rb;  
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        //if player pressed horizontal keys (a or d or left or right)
        //returns a value of +1, 0 or -1 depending on user input

        horizontal = Input.GetAxisRaw("Horizontal"); 

        Flip(); //calling flip in so the character can be flipped
    }

    private void FixedUpdate()
    {
        //formula for calculating velocity
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() 
    {
        //ensures that the character is grounded
        //creates an invisible circle right at the player's feet. When it collides with the ground layer they can jump.
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight; //flipping the player by setting each state as the other 
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
