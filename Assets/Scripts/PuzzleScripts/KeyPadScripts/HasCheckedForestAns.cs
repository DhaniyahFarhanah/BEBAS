using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasCheckedForestAns : MonoBehaviour
{
    [SerializeField] private GameObject triggerKeypad;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!triggerKeypad)
            triggerKeypad = GameObject.Find("Keypad trigger");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerKeypad.SetActive(true);
    }
}
