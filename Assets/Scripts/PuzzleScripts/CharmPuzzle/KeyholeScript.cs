using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyholeScript : MonoBehaviour
{
    public bool canUnlock;

    [SerializeField] GameObject keyCanUnlock;
    [SerializeField] GameObject dialogueClue;
    [SerializeField] GameObject eyeClue;
    [SerializeField] Color selected;
    [SerializeField] Color notSelected;

    Image keyhole;

    private void Start()
    {
        canUnlock = false;
        keyhole = GetComponent<Image>();
    }

    private void Update()
    {
        if(canUnlock)
        {
            keyCanUnlock.SetActive(true);
            gameObject.SetActive(false);
        }

    }

    public void OnHover()
    {
       keyhole.color = selected;
       eyeClue.SetActive(true);
    }

    public void OnNotHover()
    {
        keyhole.color = notSelected;
        eyeClue.SetActive(false);
    }

    public void OnClick()
    {
        dialogueClue.SetActive(true);
    }

}
