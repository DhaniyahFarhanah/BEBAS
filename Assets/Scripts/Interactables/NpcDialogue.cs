using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Image showcase;
    public GameObject gameObj;
    public TMP_Text dialogueText;
    [SerializeField] GameObject Z;
    [SerializeField] TMP_Text nameTextBox;
    [SerializeField] Image dialogueBoxImage;
    [SerializeField] Image leftTalkingImage;
    [SerializeField] Image rightTalkingImage;
    [SerializeField] Sprite leftImage;
    [SerializeField] Sprite rightImage;

    public string[] nameOfPerson;
    public string[] dialogue;
    public Sprite[] personShowcase;
    public Sprite[] dialogueBoxImageArray;
    private int index;

    public Sprite newImage;

    public float wordSpeed;
    public float currentWordSpeed;
    public bool playerIsClose;
    public bool start = true;


    [SerializeField] private bool hasCompletedLine = false;
    [SerializeField] bool SetActiveAfterFinished;
    [SerializeField]private bool completeLineNow = false;

    private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    [SerializeField] private bool stopAudioSource;

    private void Awake()
    {
        wordSpeed = 0.1f;
        currentWordSpeed = wordSpeed;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SkipLine();


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
                SpeechAssignment();
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

        gameObj.SetActive(SetActiveAfterFinished);

    }

    IEnumerator Typing()
    {
        SpeechAssignment();
        foreach (char letter in dialogue[index].ToCharArray())
        {
            yield return new WaitForSeconds(currentWordSpeed);

            hasCompletedLine = false;
            dialogueText.text += letter;
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            audioSource.PlayOneShot(dialogueTypingSoundClip);

            if (completeLineNow)
            {
                SetWordSpeed(0.0f); // 0 means v fast
            }
            else
            {
                SetWordSpeed(wordSpeed); // set cur_wordspeed back to original value
            }
        }

        hasCompletedLine = true;
        completeLineNow = false;
    }

    private void SkipLine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasCompletedLine && !completeLineNow)
        {
            completeLineNow = true;
        }
    }

    private void SetWordSpeed(float newSpeed)
    {
        currentWordSpeed = newSpeed;
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
            Z.SetActive(true);
            nameTextBox.text = name;
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
            Z.SetActive(false);
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
            rightTalkingImage.sprite = personShowcase[index];
            leftTalkingImage.color = new Color(0.3f, 0.3f, 0.3f);
            rightTalkingImage.color = new Color(1f, 1f, 1f);
        }
        else
        {
            leftTalkingImage.sprite = personShowcase[index];
            nameTextBox.alignment = TextAlignmentOptions.Left;
            leftTalkingImage.color = new Color(1f, 1f, 1f);
            rightTalkingImage.color = new Color(0.3f, 0.3f, 0.3f);
        }

    }

}
