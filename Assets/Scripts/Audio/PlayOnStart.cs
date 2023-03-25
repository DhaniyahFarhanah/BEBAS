using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] AudioSource audioToBePlayed;
    [SerializeField] GameObject objToPlaySound;
    [SerializeField] bool stopWhenInactive;

    bool PlayOnce;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (objToPlaySound.activeInHierarchy && !PlayOnce)
        {
            audioToBePlayed.Play();
            PlayOnce = true;
        }

        if (stopWhenInactive)
        {
            if (gameObject.activeInHierarchy)
            {
                audioToBePlayed.Stop();
            }
            else
            {
                if (!audioToBePlayed.isPlaying)
                {
                    audioToBePlayed.Play();
                }
            }
        }
    } 
}
