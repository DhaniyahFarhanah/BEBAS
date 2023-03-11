using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnDialogue : MonoBehaviour
{
    EventDialogue dialogueScript;
    [SerializeField] GameObject setActive;
    [SerializeField] int index;
    // Start is called before the first frame update

    private void Awake()
    {
        dialogueScript = gameObject.GetComponent<EventDialogue>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueScript.index == index)
        {
            setActive.SetActive(true);
        }
    }
}
