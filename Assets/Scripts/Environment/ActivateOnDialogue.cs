using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnDialogue : MonoBehaviour
{
    EventDialogue dialogueScript;
    SecurityGuardMove move;
    [SerializeField] GameObject Guard;
    [SerializeField] GameObject setActive;
    [SerializeField] int index;
    // Start is called before the first frame update

    private void Awake()
    {
        move = Guard.GetComponent<SecurityGuardMove>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            move.reachedclue = true;
        }
        
    }
}
