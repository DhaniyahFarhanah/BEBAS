using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWalking : MonoBehaviour
{
    [SerializeField] GameObject eventDialogue;

    EventDialogue dialogueindex;
    SecurityGuardMove move;
    // Start is called before the first frame update
    private void Awake()
    {
        move = gameObject.GetComponent<SecurityGuardMove>();
        dialogueindex = eventDialogue.GetComponent<EventDialogue>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogueindex.index == 6)
        {
            move.isWaiting = false;
        }
    }
}
