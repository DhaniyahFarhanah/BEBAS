using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOrDisableFingerHud : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject FingerHud;
    [SerializeField] int dialogueIndex;
    
    NpcDialogue npcDialogue;
    // Start is called before the first frame update
    private void Awake()
    {
        npcDialogue = gameObject.GetComponent<NpcDialogue>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (npcDialogue.index == dialogueIndex)
        {
            FingerHud.SetActive(true);
        }

    }
}
