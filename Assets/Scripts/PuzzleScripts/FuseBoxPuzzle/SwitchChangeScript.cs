using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchChangeScript : MonoBehaviour
{
    [SerializeField] GameObject SwitchOn;
    [SerializeField] GameObject SwitchOff;

    [SerializeField] Image Light;

    [SerializeField] Sprite LightOn;
    [SerializeField] Sprite LightOff;

    public bool OnOff;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(OnOff == true)
        {
            Light.sprite = LightOn;
        }

        if(OnOff == false)
        {
            Light.sprite = LightOff;
        }
    }

    public void IsOn()
    {
        OnOff = false;
        SwitchOff.SetActive(true);
        SwitchOn.SetActive(false);
    }

    public void IsOff()
    {
        OnOff = true;
        SwitchOff.SetActive(false);
        SwitchOn.SetActive(true);
        
    }
}
