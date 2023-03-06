using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameRun : MonoBehaviour
{

    [SerializeField] GameObject player;

    PlayerStateManager isRun;
    // Start is called before the first frame update

    void Awake()
    {
        isRun = GetComponent<PlayerStateManager>();
    }
    void Start()
    {
        isRun.isRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
