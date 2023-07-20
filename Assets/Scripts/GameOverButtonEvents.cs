using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverButtonEvents : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] Image hand;
    [SerializeField] Image word;
    [SerializeField] Sprite handSelected;
    [SerializeField] Sprite handNotSelected;
    [SerializeField] Color selected;
    [SerializeField] Color notSelected;
    [SerializeField] AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onPointerEnter()
    {
        sound.Play();
        hand.sprite = handSelected;
        word.color = selected;
    }
    public void onPointerExit()
    {
        hand.sprite = handNotSelected;
        word.color = notSelected;
    }
}
