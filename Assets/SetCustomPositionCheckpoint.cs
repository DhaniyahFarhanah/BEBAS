using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCustomPositionCheckpoint : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    public float xPos;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerManager)
        {
            playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            if (!playerManager)
                Debug.LogError("You are missing a PlayerManager GameObject in scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerManager.checkpointX = xPos;
            playerManager.checkpointY = yPos;
        }
    }
}
