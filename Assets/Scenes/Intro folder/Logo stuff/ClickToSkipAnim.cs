using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ClickToSkipAnim : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    //gameobjects
    [SerializeField] GameObject digipenLogo;
    [SerializeField] GameObject spookyookyLogo;
    [SerializeField] GameObject copyrightText;
    [SerializeField] GameObject triggerWarning;
    [SerializeField] GameObject headphoneNotice;
    [SerializeField] GameObject Loader;

    //animators
    Animator digipenSpookyAnim;
    Animator spookyAnim;
    Animator copyrightAnim;
    Animator TriggerAnim;
    Animator headphoneAnim;

    [SerializeField] float waitTime;

    scenetransition load;

    [SerializeField] int click;

    private void Awake()
    {
        digipenSpookyAnim = digipenLogo.GetComponent<Animator>();
        copyrightAnim = copyrightText.GetComponent<Animator>();
        TriggerAnim = triggerWarning.GetComponent<Animator>();
        headphoneAnim = headphoneNotice.GetComponent<Animator>();
        spookyAnim = spookyookyLogo.GetComponent<Animator>();
        load = Loader.GetComponent<scenetransition>();
    }

    // Start is called before the first frame update
    void Start()
    {
        click = 0;
        StartCoroutine(waitforclick());
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnim();

        if(click == 3)
        {
            waitTime = 3f;
        }
        else if (click == 4)
        {
            waitTime = 2f;
        }
       
    }

    public void addClick()
    {
        click++;
    }

    void PlayAnim()
    {
        switch (click)
        {
            case 0: 
                digipenSpookyAnim.SetBool("isDigipen", true);
                break;

            case 1:
                digipenSpookyAnim.SetBool("isDigipen", true);
                digipenSpookyAnim.SetTrigger("Gone");
                break;

            case 2:
                digipenLogo.SetActive(false);
                spookyookyLogo.SetActive(true);
                digipenSpookyAnim.SetBool("isDigipen", false);
                spookyAnim.SetBool("isSpooky", true);
                break;

            case 3:
                copyrightAnim.SetTrigger("Gone");
                spookyAnim.SetTrigger("Gone");
                break;

            case 4:
                spookyookyLogo.SetActive(false);
                triggerWarning.SetActive(true);
                break;

            case 5:
                TriggerAnim.SetTrigger("Gone");
                break;

            case 6:
                triggerWarning.SetActive(false);
                headphoneNotice.SetActive(true);
                break;

            case 7:
                headphoneAnim.SetTrigger("Gone");
                break;

            case 8:

                Loader.SetActive(true);
                load.LoadNextLevel();
                break;

        }
    }

    IEnumerator waitforclick()
    {
       
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            click = click + 1;
        }
        
    }
  
}
