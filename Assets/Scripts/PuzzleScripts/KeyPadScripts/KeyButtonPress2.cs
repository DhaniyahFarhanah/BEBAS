using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButtonPress2 : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    public static event Action<String> ButtonPressed2 = delegate { };

    private int dividerPosition;
    private String buttonName, buttonValue;

    private PlayAudio buttonPresed;

    private void Awake()
    {
        TryGetComponent(out buttonPresed);
    }
    void Start()
    {
        buttonName = gameObject.name;
        dividerPosition = buttonName.IndexOf("_");
        buttonValue = buttonName.Substring(0, dividerPosition);

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        ButtonPressed2(buttonValue);
        buttonPresed.Play();
    }
}
