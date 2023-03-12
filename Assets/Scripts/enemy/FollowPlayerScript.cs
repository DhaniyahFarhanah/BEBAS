using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject DialogueBox;

    public bool isWaiting;

    Rigidbody2D rb;
    BoxCollider2D killSensor;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        killSensor = gameObject.GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        isWaiting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            killSensor.enabled = false;
        }
        else
        {
            killSensor.enabled = true;
        }

        if (!DialogueBox.activeInHierarchy && isWaiting)
        {
            StartCoroutine(WaitForAgro());
        }
        else
        {
            ChasePlayer();
        }
       
    }

    void ChasePlayer()
    {
        Debug.Log("move damn it");
        rb.velocity = new Vector2(-moveSpeed, 0);
        
    }

    IEnumerator WaitForAgro()
    {
        yield return new WaitForSeconds(4f);
        //play anim of revival here
        ChasePlayer();
        isWaiting = false;
    }
}
