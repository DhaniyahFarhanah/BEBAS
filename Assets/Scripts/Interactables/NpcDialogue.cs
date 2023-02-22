using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Image showcase;
    public GameObject gameObj;
    public TMP_Text dialogueText;
    [SerializeField] TMP_Text nameTextBox;
    [SerializeField] Image dialogueBoxImage;
    [SerializeField] Image leftTalkingImage;
    [SerializeField] Image rightTalkingImage;
    [SerializeField] Sprite leftImage;
    [SerializeField] Sprite rightImage;
    [SerializeField] GameObject NPCImageGO;

    public string[] nameOfPerson;
    public string[] dialogue;
    public Sprite[] personShowcase;
    public Sprite[] dialogueBoxImageArray;
    private int index;

    public Sprite newImage;

    public float wordSpeed;
    public bool playerIsClose;
    public bool start = true;


    [SerializeField] private bool hasCompletedLine = false;
    [SerializeField] bool SetActiveAfterFinished;

    private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    [SerializeField] private bool stopAudioSource;

    private void Awake()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        AssignItems();
    }

    // Update is called once per frame
    void Update()
    {
        SpeechAssignment();

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
        NPCImageGO.SetActive(false);

        gameObj.SetActive(SetActiveAfterFinished);
        
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            hasCompletedLine = false;
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            audioSource.PlayOneShot(dialogueTypingSoundClip);
            yield return new WaitForSeconds(wordSpeed);
        }

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
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            AssignItems();
            start = false;
            dialoguePanel.SetActive(true);
            NPCImageGO.SetActive(true);
            nameTextBox.text = name;
            StartCoroutine(Typing());
            playerIsClose = true;
            showcase.sprite = newImage;
            
            Debug.Log("Scared as hell");
        }
    }

    private void OnTriggerExit2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            playerIsClose = false;
            Debug.Log("Player is out of range");
            zeroText();
        }
    }

    void AssignItems()
    {
        leftTalkingImage.sprite = leftImage;
        rightTalkingImage.sprite = rightImage;

    }

    void SpeechAssignment()
    {
        nameTextBox.text = nameOfPerson[index];
        dialogueBoxImage.sprite = dialogueBoxImageArray[index];

        if (nameOfPerson[index] != "Azri")
        {
            nameTextBox.alignment = TextAlignmentOptions.Right;
            leftTalkingImage.color = new Color(0.3f, 0.3f, 0.3f);
            rightTalkingImage.color = new Color(1f, 1f, 1f);
        }
        else
        {
            nameTextBox.alignment = TextAlignmentOptions.Left;
            leftTalkingImage.color = new Color(1f, 1f, 1f);
            rightTalkingImage.color = new Color(0.3f, 0.3f, 0.3f);
        }

    }

}
