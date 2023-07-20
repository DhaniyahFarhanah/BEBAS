using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbulbClink : MonoBehaviour
{
    [SerializeField] GameObject Darkness;
    [SerializeField] AudioSource clink;
    [SerializeField] bool PlayOnce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Darkness.activeInHierarchy)
        {
            if(!clink.isPlaying && !PlayOnce)
            {
                clink.Play();

            }
            PlayOnce = true;
        }
        else
        {
            PlayOnce = false;

        }
    }
}
