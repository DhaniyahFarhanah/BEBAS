using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject doorToEndgame;
    [SerializeField] GameObject doorToWard;
    [SerializeField] GameObject start;

    PlayerStateManager playerStateManager;
    

    private void Awake()
    {
        playerStateManager = player.GetComponent<PlayerStateManager>();
    }
    void Start()
    {
        playerStateManager.isRun = true;
        doorToWard.SetActive(false);
        doorToEndgame.SetActive(true);
        start.SetActive(true);
        //Activate Run
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
