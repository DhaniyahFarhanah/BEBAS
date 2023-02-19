using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitPuzzle : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            player.SetActive(true);
            
        }
    }
}
