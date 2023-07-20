using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnKnob : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject display;

    bool playOnce;

    Animator knob;
    DigitalDisplay digitalDisplay;
    // Start is called before the first frame update
    private void Awake()
    {
        digitalDisplay = display.GetComponent<DigitalDisplay>();
    }
    void Start()
    {
        knob = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (digitalDisplay.playAnim)
        {
            if (digitalDisplay.isCorrect && !playOnce)
            {
              knob.SetBool("Correct", true);
              playOnce = false;
            }
             else if (digitalDisplay.isWrong && !playOnce)
            {
                knob.SetTrigger("WrongTrigger");
                playOnce = false;

            }

            digitalDisplay.playAnim = false;

        }
    }

    
}
