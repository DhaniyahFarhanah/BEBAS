using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingGhost : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] AudioSource ropeAudio;
    // Start is called before the first frame update
    void Start()
    {
        ropeAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Debug.Log("Death");   
            
        }
    }
}
