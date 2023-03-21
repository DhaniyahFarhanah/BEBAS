using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject objToPlaySound;
    [SerializeField] bool stopWhenInactive;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (objToPlaySound.activeInHierarchy)
        {
            audio.Play();
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
