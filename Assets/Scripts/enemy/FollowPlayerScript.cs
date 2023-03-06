using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject DialogueBox;

    Transform playerTransform;
    Rigidbody2D rb;
    

    private void Awake()
    {
            rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform && !DialogueBox.activeInHierarchy)
        {
            StartCoroutine(WaitForAgro());
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void ChasePlayer()
    {
        rb.velocity = new Vector2(-moveSpeed, 0);
        
    }

    IEnumerator WaitForAgro()
    {
        yield return new WaitForSeconds(4f);
        //play anim of revival here
        ChasePlayer();
    }
}
