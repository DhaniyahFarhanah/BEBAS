using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Image showcase;
    public GameObject gameObj;
    public TMP_Text dialogueText;
    [SerializeField] TMP_Text nameTextBox;

    public Sprite newImage;
    //AzriReactions
    [SerializeField] Image AzriPreview;
    [SerializeField] Sprite AzriDefault;
    [SerializeField] Sprite[] AzriReactions;


    public new string name;
    public string[] dialogue;
    public int index;

    [SerializeField] bool isPickUp;

    public float wordSpeed;
    public float currentWordSpeed;
    public bool playerIsClose;
    public bool start = true;



    [SerializeField] private bool hasCompletedLine = false;
    [SerializeField] bool SetActiveAfterFinished;
    private bool completeLineNow = false;

    private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    [SerializeField] private bool stopAudioSource;

    private void Awake()
    {
        wordSpeed = 0.03f;
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
            //Debug.Log("Interact");

            //if (dialoguePanel.activeInHierarchy)
            //{
            //    zeroText();
            //}

            //else
            //{
            //start = false;
            //dialoguePanel.SetActive(true);
            //index = 0;
            //StartCoroutine(Typing());
            //}
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
        AzriPreview.sprite = AzriDefault;
        gameObj.SetActive(SetActiveAfterFinished);

    }

    IEnumerator Typing()
    {
        AzriPreview.sprite = AzriReactions[index];
        foreach (char letter in dialogue[index].ToCharArray())
        {
            yield return new WaitForSeconds(currentWordSpeed);

            dialogueText.text += letter;
            hasCompletedLine = false;
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            audioSource.PlayOneShot(dialogueTypingSoundClip);

            if (completeLineNow)
            {
                SetWordSpeed(0); // 0 means v fast
            }
            else
            {
                SetWordSpeed(wordSpeed); // set cur_wordspeed back to original value
            }
        }
        completeLineNow = false;
        hasCompletedLine = true;
    }

    private void SkipLine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasCompletedLine && !completeLineNow && !start)
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

    private bool dialogueAppearedBefore = false;
    private void OnTriggerEnter2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            if (start && !dialogueAppearedBefore)
            {
                dialogueAppearedBefore = true;
                start = false;
                dialoguePanel.SetActive(true);
                nameTextBox.text = name;
                StartCoroutine(Typing());
                playerIsClose = true;
                showcase.sprite = newImage;
                
            }

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

}
