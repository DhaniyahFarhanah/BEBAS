using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ClickToSkipAnim : MonoBehaviour
{
    //gameobjects
    [SerializeField] GameObject digipenLogo;
    [SerializeField] GameObject spookyookyLogo;
    [SerializeField] GameObject copyrightText;
    [SerializeField] GameObject triggerWarning;
    [SerializeField] GameObject headphoneNotice;
    [SerializeField] GameObject Loader;

    //animators
    Animator digipenSpookyAnim;
    Animator copyrightAnim;
    Animator TriggerAnim;
    Animator headphoneAnim;

    scenetransition load;

    [SerializeField] int click;

    private void Awake()
    {
        digipenSpookyAnim = digipenLogo.GetComponent<Animator>();
        copyrightAnim = copyrightText.GetComponent<Animator>();
        TriggerAnim = triggerWarning.GetComponent<Animator>();
        headphoneAnim = headphoneNotice.GetComponent<Animator>();
        load = Loader.GetComponent<scenetransition>();
    }

    // Start is called before the first frame update
    void Start()
    {
        click = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnim();
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
                digipenSpookyAnim.SetBool("isSpooky", true);
                break;

        }
    }

  
}
