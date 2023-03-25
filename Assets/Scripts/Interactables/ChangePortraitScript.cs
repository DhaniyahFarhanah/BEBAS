using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePortraitScript : MonoBehaviour
{
    //Script by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] SpriteRenderer PictureInGame;
    [SerializeField] Image PictureInDialogue;
    [SerializeField] Sprite PictureTear;
    [SerializeField] Sprite Picture;
    [SerializeField] AudioSource tear;
    [SerializeField] DialogueScript script;

    bool fivePlayOnce;
    bool fourPlayOnce;
        // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(script.index == 4)
        {
            PictureInDialogue.sprite = PictureTear;
            if (!tear.isPlaying && !fourPlayOnce)
            {
                tear.Play();
                fourPlayOnce = true;
            }
        }

        if(script.index == 5)
        {
            PictureInDialogue.sprite = Picture;
            PictureInGame.sprite = Picture;
            if (!tear.isPlaying && !fivePlayOnce)
            {
                tear.Play();
                fivePlayOnce = true;
            }
        }
        
    }
}
