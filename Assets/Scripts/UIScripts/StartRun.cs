using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject doorToEndgame;
    [SerializeField] GameObject doorToWard;

    PlayerStateManager playerStateManager;
    

    private void Awake()
    {
        playerStateManager = player.GetComponent<PlayerStateManager>();
    }
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
            playerStateManager.isRun = true;
            doorToWard.SetActive(false);
            doorToEndgame.SetActive(true);
            //Activate Run
        }
    }
}
