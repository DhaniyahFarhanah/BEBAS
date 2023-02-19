using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadPuzzleScript : MonoBehaviour
{
    //pseudocode time
    // get bool of the switches 
    SwitchChangeScript Switch1;
    SwitchChangeScript Switch2;
    SwitchChangeScript Switch3;
    SwitchChangeScript Switch4;

    [SerializeField] GameObject Darkness;
    [SerializeField] GameObject spark;
    [SerializeField] GameObject Switch_1;
    [SerializeField] GameObject Switch_2;
    [SerializeField] GameObject Switch_3;
    [SerializeField] GameObject Switch_4;

    [SerializeField] bool Switch1_On;
    [SerializeField] bool Switch2_On;
    [SerializeField] bool Switch3_On;
    [SerializeField] bool Switch4_On;

    [SerializeField] Animator anim;

    [SerializeField] Image statusBar;

    float currentVelocity;

    int Switch1Val;
    int Switch2Val;
    int Switch3Val;
    int Switch4Val;

    [SerializeField] int correctValue;
    [SerializeField] float enteredValue;

    // int of the right number plus
    // bar to transform bar. 
    // Start is called before the first frame update

    void Awake()
    {
        Switch1 = Switch_1.GetComponent<SwitchChangeScript>();
        Switch2 = Switch_2.GetComponent<SwitchChangeScript>();
        Switch3 = Switch_3.GetComponent<SwitchChangeScript>();
        Switch4 = Switch_4.GetComponent<SwitchChangeScript>();

    }

    void Start()
    {
       // barRect = statusBar.rectTransform.rect;
       // MaxBarSize = barRect.width;      
    }

    // Update is called once per frame
    void Update()
    {
        CheckRight();
    }

    //checkright
    //it checks the combi

    void CheckRight()
    {
        AddValue();
        SetBar();

        if(enteredValue == correctValue)
        {
            StartCoroutine(LightsOn());
            Debug.Log("Right amount");
        }
        else
        {
            anim.SetBool("On", false);
            Debug.Log("Wrong Amount");
        }
    }
    
    void AddValue()
    {
        AssignBool();

        enteredValue = Switch1Val + Switch2Val + Switch3Val + Switch4Val;

        Overload();

    }

    void Overload()
    {
        if (statusBar.fillAmount > 0.8)
        {
            StartCoroutine(AllowOverload());
            Switch1.OnOff = false;
            Switch1.IsOn();
            Switch2.OnOff = false;
            Switch2.IsOn();
            Switch3.OnOff = false;
            Switch3.IsOn();
            Switch4.OnOff = false;
            Switch4.IsOn();
        }
    }

    void AssignBool()
    {
        Switch1_On = Switch1.OnOff;
        Switch2_On = Switch2.OnOff;
        Switch3_On = Switch3.OnOff;
        Switch4_On = Switch4.OnOff;

        switch (Switch1_On)
        {
            case true: Switch1Val = 10;
                    break;
            case false: Switch1Val = 0;
                break;
        }
        switch (Switch2_On)
        {
            case true:
                Switch2Val = 20;
                break;
            case false:
                Switch2Val = 0;
                break;
        }
        switch (Switch3_On)
        {
            case true:
                Switch3Val = 30;
                break;
            case false:
                Switch3Val = 0;
                break;
        }
        switch (Switch4_On)
        {
            case true:
                Switch4Val = 40;
                break;
            case false:
                Switch4Val = 0;
                break;
        }

    }

    void SetBar()
    {
        float barSlide = Mathf.SmoothDamp(statusBar.fillAmount, enteredValue / 100, ref currentVelocity, 100 * Time.deltaTime);
        statusBar.fillAmount = barSlide;
        
    }

    IEnumerator AllowOverload()
    {
        anim.SetTrigger("Shake");
        spark.SetActive(true);
        yield return new WaitForSeconds(1f);
        spark.SetActive(false);

    }

    IEnumerator LightsOn()
    {
        
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("On", true);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }

}
