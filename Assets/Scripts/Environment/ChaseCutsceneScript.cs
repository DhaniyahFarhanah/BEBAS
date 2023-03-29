using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCutsceneScript : MonoBehaviour
{
    [SerializeField] GameObject AgroChase;
    [SerializeField] GameObject environment;
    [SerializeField] GameObject npcDialoguepanel;
    [SerializeField] GameObject NoAgro;
    [SerializeField] GameObject player;

    bool flipOnce;

    SpriteRenderer playerSR;
    Animator environmentAnimator;
    [SerializeField] bool StartRun;
    NpcDialogue ghostDialogue;

    // Start is called before the first frame update
    private void Awake()
    {
        ghostDialogue = gameObject.GetComponent<NpcDialogue>();
        environmentAnimator = environment.GetComponent<Animator>();
        playerSR = player.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        StartRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartRun)
        {
            StartCutscene();
        }

        else if (StartRun && !npcDialoguepanel.activeInHierarchy)
        {
            environmentAnimator.SetBool("Shake", false);
            SetActives();
        }
        
    }

    void StartCutscene()
    {
        if(ghostDialogue.index == 9)
        {
            environmentAnimator.SetBool("Shake",true);
        }

        if(ghostDialogue.index == 12)
        {
            StartRun = true;
        }


    }

    void SetActives()
    {
        if(playerSR.flipX == false && !flipOnce)
        {
            playerSR.flipX = true;
            flipOnce = true;
        }
        ghostDialogue.enabled = false;
        NoAgro.SetActive(false);   
        AgroChase.SetActive(true);

    }
}
