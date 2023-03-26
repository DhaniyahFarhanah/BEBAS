using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff
    //Script modified by Stella

    public GameObject dialoguePanel;
    public Image showcase;
    public GameObject gameObj;
    public TMP_Text dialogueText;
    [SerializeField] bool doneTalk;
    [SerializeField] GameObject Z;
    [SerializeField] TMP_Text nameTextBox;
    [SerializeField] Image dialogueBoxImage;
    [SerializeField] Image leftTalkingImage;
    [SerializeField] Image rightTalkingImage;
    [SerializeField] Sprite leftImage;
    [SerializeField] Sprite rightImage;
    [SerializeField] Image Arrow;

    [SerializeField] TMP_FontAsset NPCFont;
    [SerializeField] Color NPCTextColor;
    [SerializeField] int NPCfontsize;
    [SerializeField] Sprite NPCArrow;
    [SerializeField] TMP_FontAsset AzriFont;
    [SerializeField] Color AzriTextColor;
    [SerializeField] int Azrifontsize;
    [SerializeField] Sprite AzriArrow;

    public string[] nameOfPerson;
    public string[] dialogue;
    public Sprite[] personShowcase;
    public Sprite[] dialogueBoxImageArray;
    public int index;

    public Sprite newImage;

    public float wordSpeed;
    public float currentWordSpeed;
    public bool playerIsClose;
    public bool start = true;

    pausemenu pause;


    [SerializeField] private bool hasCompletedLine = false;
    [SerializeField] bool SetActiveAfterFinished;
    [SerializeField] private bool completeLineNow = false;

    private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    [SerializeField] private List<AudioClip> azriAudioClips = new List<AudioClip>();
    [SerializeField] private int azriTalkingIndex = 0;
    [SerializeField] private bool stopAudioSource;

    [Range(1.0f, 4.0f)]
    [SerializeField] private float delayGhostTalking = 2f;    // The value that waits for 'delayGhostTalking' seconds before ghost talks again
    [SerializeField] private bool startAudio = false;   // Need a bool so that run coroutine once only
    IEnumerator ghostTalking;   // Keeps a reference of the ghost talking, so to stop audio later on
    IEnumerator azriTalking;   // Keeps a reference of the azri talking, so to stop audio later on
    
    private void Awake()
    {
        wordSpeed = 0.1f;
        currentWordSpeed = wordSpeed;
        if (!audioSource)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            if (!audioSource)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        if (audioSource.clip == null)
        {
            audioSource.clip = dialogueTypingSoundClip;
        }

        pause = GameObject.FindGameObjectWithTag("menu").GetComponent<pausemenu>();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SkipLine();
        
        PlayTalkingSound();

        if (doneTalk)
        {
            Z.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && playerIsClose && start == true && !pause.isPaused && !doneTalk)
        {
            Debug.Log("Interact");
            Z.GetComponent<PlayAudio>().Play();

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

        else if (Input.GetKeyDown(KeyCode.Mouse0) && start == false && hasCompletedLine && !pause.isPaused)
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
        doneTalk = true;
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
            //if (stopAudioSource)
            //{
            //    audioSource.Stop();
            //}
            //audioSource.PlayOneShot(dialogueTypingSoundClip);

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

    // Play audio based on who is talking
    private void PlayTalkingSound()
    {
        if (dialoguePanel.activeSelf == true && playerIsClose)
        {
            if (nameOfPerson[index] != "Azri" && startAudio == false)
            {
                // Play Ghost talk sound
                startAudio = true;

                ghostTalking = CryingGhostTalking();
                StartCoroutine(ghostTalking);

                if (azriTalking != null)
                    StopCoroutine(azriTalking);
            }
            else if (nameOfPerson[index] == "Azri" && startAudio == true)
            {
                // Stop ghost talk sound
                startAudio = false;
                if (ghostTalking != null)
                    StopCoroutine(ghostTalking);

                azriTalking = AzriTalking();
                StartCoroutine(azriTalking);
            }
        }
        else
        {
            if (ghostTalking != null)
            {
                startAudio = false;
                StopCoroutine(ghostTalking);
            }
            if (azriTalking != null)
            {
                StopCoroutine(azriTalking);
            }
        }
    }

    // "Loop" ghost talking but with a delay variable
    IEnumerator CryingGhostTalking()
    {
        audioSource.clip = dialogueTypingSoundClip;
        while (true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length + delayGhostTalking);
        }
    }
    // "Loop" azri talking but with a delay variable
    IEnumerator AzriTalking()
    {
        audioSource.clip = azriAudioClips[azriTalkingIndex];
        azriTalkingIndex = (azriTalkingIndex + 1 > azriAudioClips.Count - 1) ? 0 : azriTalkingIndex + 1;

        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitForSeconds(audioSource.clip.length + 1);
        //while (true)
        //{
        //    audioSource.Play();
        //    yield return new WaitForSeconds(audioSource.clip.length + 1);
        //}
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
            dialogueText.text = "";
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
            dialogueText.color = NPCTextColor;
            nameTextBox.color = NPCTextColor;
            dialogueText.font = NPCFont;
            dialogueText.fontSize = NPCfontsize;
            nameTextBox.font = NPCFont;
            Arrow.sprite = NPCArrow;
            rightTalkingImage.sprite = personShowcase[index];
            leftTalkingImage.color = new Color(0.3f, 0.3f, 0.3f);
            rightTalkingImage.color = new Color(1f, 1f, 1f);
        }
        else
        {
            dialogueText.color = AzriTextColor;
            nameTextBox.color = AzriTextColor;
            dialogueText.font = AzriFont;
            nameTextBox.font = AzriFont;
            dialogueText.fontSize = Azrifontsize;
            Arrow.sprite = AzriArrow;
            leftTalkingImage.sprite = personShowcase[index];
            leftTalkingImage.color = new Color(1f, 1f, 1f);
            rightTalkingImage.color = new Color(0.3f, 0.3f, 0.3f);
        }

    }

}
