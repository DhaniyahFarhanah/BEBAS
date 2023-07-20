using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWhenDialogueOpen : MonoBehaviour
{
    [SerializeField] GameObject dialoguebox;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialoguebox.activeInHierarchy)
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
