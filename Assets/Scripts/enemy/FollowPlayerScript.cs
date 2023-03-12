using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject DialogueBox;
    [SerializeField] GameObject player;
    [SerializeField] GameObject AgroInWard;

    [SerializeField] bool isWaiting;
    public bool AzriInWard;
    public bool isKilled;

    Transform playerTransform;
    Rigidbody2D rb;
    BoxCollider2D killSensor;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        killSensor = gameObject.GetComponent<BoxCollider2D>();
        playerTransform = player.GetComponent<Transform>();
    }
    void Start()
    {
        isWaiting = true;
        AzriInWard = false;
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

        if (AzriInWard)
        {
            //spawn in ward
            AgroInWard.SetActive(true);
            gameObject.IsDestroyed();

        }

        if (isKilled)
        {
            StopAllCoroutines();
        }
       
    }

    void ChasePlayer()
    {
        Debug.Log("move damn it");
        rb.velocity = new Vector2(-moveSpeed, 0);

        if(transform.position.x == playerTransform.position.x)
        {
            isKilled = true;
            rb.velocity = Vector2.zero;
        }
        
    }

    IEnumerator WaitForAgro()
    {
        yield return new WaitForSeconds(4f);
        //play anim of revival here
        ChasePlayer();
        isWaiting = false;
    }

    
}
