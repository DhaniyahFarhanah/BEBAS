using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    [SerializeField] AudioSource audio;
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
            audio.Play();
            PlayOnce = true;
        }

        if (stopWhenInactive)
        {
            if (gameObject.activeInHierarchy)
            {
                audio.Stop();
            }
            else
            {
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
            }
        }
    } 
}
