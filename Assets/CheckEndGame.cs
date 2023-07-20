using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool endgame;
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
            endgame = true;
        }
    }
}
