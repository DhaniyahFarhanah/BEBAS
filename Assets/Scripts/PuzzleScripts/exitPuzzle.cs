using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitPuzzle : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogue;
    public bool canClose;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeInHierarchy && canClose && !dialogue.activeInHierarchy)
        {
            gameObject.SetActive(false);
            player.SetActive(true);
            
        }
    }
}
