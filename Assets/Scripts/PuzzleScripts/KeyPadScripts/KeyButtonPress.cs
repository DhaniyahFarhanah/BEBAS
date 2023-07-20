using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButtonPress : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    public static event Action<String> ButtonPressed = delegate { };

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
        ButtonPressed(buttonValue);
        buttonPresed.Play();
    }
}
