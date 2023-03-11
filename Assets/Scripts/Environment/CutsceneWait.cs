using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneWait : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float waitTime;
    [SerializeField] int dialogueIndex;
    [SerializeField] bool flipPlayerLeft;
    [SerializeField] bool flipPlayerRight;
    
    EventDialogue eventScript;
    SpriteRenderer playerSR;

    private void Awake()
    {
        eventScript = gameObject.GetComponent<EventDialogue>();
        playerSR = player.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForGhost());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForGhost()
    {
        yield return new WaitForSeconds(waitTime);
        eventScript.index = dialogueIndex;

        if(eventScript.index == dialogueIndex)
        {
            //want to force player to switch direction (face left)
            if (flipPlayerLeft)
            {
                if(playerSR.flipX == false)
                {
                    playerSR.flipX = true;
                }
            }

            //want to force player to switch direction

            else if (flipPlayerRight)
            {
                if(playerSR.flipX == true)
                {
                    playerSR.flipX = false;
                }
            }
            
        }

    }
}
