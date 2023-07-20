using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] Image PictureInDialogue;
    [SerializeField] Sprite Key;
    [SerializeField] AudioSource keySound;
    [SerializeField] EventDialogue script;

    bool playOnce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(script.index == 4)
        {
            PictureInDialogue.sprite = Key;

            if (!keySound.isPlaying && !playOnce)
            {
                keySound.Play();
                playOnce = true;
            }
        }
    }
}
