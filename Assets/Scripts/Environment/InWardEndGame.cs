using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWardEndGame : MonoBehaviour
{
    [SerializeField] GameObject tortured;
    [SerializeField] GameObject lighting;

    FollowPlayerScript azriWardCheck;

    private void Awake()
    {
        azriWardCheck = tortured.GetComponent<FollowPlayerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lighting.SetActive(true);
            azriWardCheck.AzriInWard = true;
            FindObjectOfType<PlayerManager>().checkpointX = FindObjectOfType<PlayerStateManager>().transform.position.x;
            FindObjectOfType<PlayerManager>().checkpointY = FindObjectOfType<PlayerStateManager>().transform.position.y;
            Debug.Log("Set checkpoint from inwardendgame.cs");
        }
    }
}
