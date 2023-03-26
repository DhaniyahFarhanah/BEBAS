using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventDialogue : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff
    //Script modified by Stella

    public GameObject dialoguePanel;
    public Image showcase;
    public GameObject gameObj;
    public TMP_Text dialogueText;
    [SerializeField] TMP_Text nameTextBox;

    [SerializeField] bool hasAudioAfter;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip audioClip;

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
    public bool hasAudioTrigger;
    bool audioPlayOnce;

    pausemenu pause;

    [SerializeField] private bool hasCompletedLine = false;
    [SerializeField] bool SetActiveAfterFinished;
    private bool completeLineNow = false;

    [SerializeField] AudioSource triggerAudio;

    private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    [SerializeField] private bool stopAudioSource;
    [SerializeField] private List<AudioClip> azriAudioClips = new List<AudioClip>();
    [SerializeField] private int azriTalkingIndex = 0;
    IEnumerator azriTalking;   // Keeps a reference of the azri talking, so to stop audio later on

    private void Awake()
    {
        wordSpeed = 0.03f;
        currentWordSpeed = wordSpeed;
        audioSource = gameObject.AddComponent<AudioSource>();

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerIsClose && start == true && !pause.isPaused)
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

        

        AzriPreview.sprite = AzriDefault;
        if (hasAudioAfter && !audiosource.isPlaying)
        {
            audiosource.clip = audioClip;
            audiosource.Play();
        }
        
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
            //if (stopAudioSource)
            //{
            //    audioSource.Stop();
            //}
            //audioSource.PlayOneShot(dialogueTypingSoundClip);

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

    // Play audio based on who is talking
    private void PlayTalkingSound()
    {
        if (dialoguePanel.activeSelf == true && playerIsClose)
        {
            if (azriTalking == null)
            {
                azriTalking = AzriTalking();
                StartCoroutine(azriTalking);
            }
        }
        else
        {
            if (azriTalking != null)
            {
                StopCoroutine(azriTalking);
                azriTalking = null;
            }
        }
    }
    // "Loop" ghost talking but with a delay variable
    IEnumerator AzriTalking()
    {
        audioSource.clip = azriAudioClips[azriTalkingIndex];
        while (true)
        {
            audioSource.PlayOneShot(audioSource.clip);
            
            azriTalkingIndex = (azriTalkingIndex + 1 > azriAudioClips.Count - 1) ? 0 : azriTalkingIndex + 1;
            audioSource.clip = azriAudioClips[azriTalkingIndex];
            yield return new WaitForSeconds(audioSource.clip.length + 2.5f);
            
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

            if (hasAudioTrigger && ! audioPlayOnce)
            {
                triggerAudio.Play();
                audioPlayOnce = true;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
            dialogueText.text = "";
            
        }
    }

}
