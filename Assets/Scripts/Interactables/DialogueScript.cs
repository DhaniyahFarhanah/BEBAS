using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject Z;
    public GameObject gameObj;
    public Image display;
    public Sprite newImage;
    public TMP_Text dialogueText;
    public Image preview;
    public bool pickUp;

    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    GameObject player;

    public string[] dialogue;
    private int index;
    [SerializeField] private bool hasCompletedLine = false;

    public float wordSpeed;
    public bool playerIsClose;
    public bool start = true;
    

    private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    [SerializeField] private bool stopAudioSource;

    private void Awake()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerIsClose && start == true)
        {
            Debug.Log("Interact");

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            
            else
            {
                start = false;
                dialoguePanel.SetActive(true);
                index = 0;
                StartCoroutine(Typing());

                if (player != null)
                {
                    // Add to inventory
                    Inventory playerInventory = player.GetComponentInChildren<Inventory>();
                    playerInventory.AddToInventory(newImage);
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && start == false && hasCompletedLine)
        {
            NextLine();
           
        }

    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        start = true;
        dialoguePanel.SetActive(false);



    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            hasCompletedLine = false;
            dialogueText.text += letter;
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            audioSource.PlayOneShot(dialogueTypingSoundClip);
            yield return new WaitForSeconds(wordSpeed);
            
        }
        // TLDR: Dont allow skipping of text, player must read finish all the letters then can go to next line of dialogue
        hasCompletedLine = true;
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            if (pickUp == true)
            {
                spriteRenderer.enabled = false;
                boxCollider.enabled = false;
            }

            zeroText();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            playerIsClose = true;
            Z.SetActive(true);
            display.sprite = newImage;
            player = interact.gameObject;
                       
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            playerIsClose = false;
            Debug.Log("Player is out of range");
            Z.SetActive(false);
            zeroText();
        }
    }

}
