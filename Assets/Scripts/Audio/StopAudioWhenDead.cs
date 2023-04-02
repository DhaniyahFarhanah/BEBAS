using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudioWhenDead : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.activeInHierarchy)
        {
            audioSource.Stop();
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
