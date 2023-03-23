using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitPuzzle : MonoBehaviour
{
    public GameObject player;
    public bool canClose;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeInHierarchy && canClose)
        {
            gameObject.SetActive(false);
            player.SetActive(true);
            
        }
    }
}
