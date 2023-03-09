using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerAddToCollection : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int fingerIndex;

    PlayerCheckPickUpFinger addFinger;
    DialogueScript dialogue;
    // Start is called before the first frame update

    private void Awake()
    {
        dialogue = gameObject.GetComponent<DialogueScript>();
        addFinger = player.GetComponent<PlayerCheckPickUpFinger>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PickUpFinger();
    }

    void PickUpFinger()
    {
        if(dialogue.index == 1)
        {
            addFinger.HasFinger[fingerIndex] = true;

        }
    }
}
