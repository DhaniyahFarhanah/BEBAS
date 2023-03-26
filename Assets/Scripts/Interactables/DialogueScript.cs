using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff
    //Script modified by Stella

    public GameObject dialoguePanel;
    public GameObject Z;
    public GameObject gameObj;
    public Image display;
    public Sprite newImage;
    public TMP_Text dialogueText;
    public bool pickUp;

    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;

    //this is for pick up audio
    [SerializeField] bool HasItemAudio;
    [SerializeField] AudioSource bagAudio;
    GameObject player;

    // Azri reactions
    [SerializeField] Image AzriPreview;
    [SerializeField] Sprite AzriDefault;
    [SerializeField] Sprite[] AzriReactions;

    public string[] dialogue;
    public int index;
    [SerializeField] private bool hasCompletedLine = false;
    private bool completeLineNow = false;

    public float wordSpeed;
    public float currentWordSpeed;
    public bool playerIsClose;
    public bool start = true;

    pausemenu pause;
    

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
        
        if (audioSource == null)
            audioSource = this.gameObject.AddComponent<AudioSource>();
        else
            audioSource = this.gameObject.GetComponent<AudioSource>();
        pause = GameObject.FindGameObjectWithTag("menu").GetComponent<pausemenu>();
    }

    // Update is called once per frame
    void Update()
    {

        SkipLine();
        
        PlayTalkingSound();

        if (Input.GetKeyDown(KeyCode.Mouse0) && playerIsClose && start == true && !pause.isPaused)
        {
            Z.GetComponent<PlayAudio>().Play();
            Debug.Log("Interact");
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            
            else
            {
                start = false;
                dialoguePanel.SetActive(true);
                display.enabled = true;
                index = 0;
                StartCoroutine(Typing());

                if (player != null && pickUp)
                {
                    // Add to inventory
                    Inventory playerInventory = player.GetComponentInChildren<Inventory>();
                    playerInventory.AddToInventory(newImage);
                }
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
        AzriPreview.sprite = AzriDefault;
        if (pickUp)
        {
            bagAudio.Play();
        }
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        //_talking.Play();
        AzriPreview.sprite = AzriReactions[index];
        foreach(char letter in dialogue[index].ToCharArray())
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
                SetWordSpeed(0); // 0 means v fast
            else
                SetWordSpeed(wordSpeed); // set cur_wordspeed back to original value
        }
        completeLineNow = false;
        hasCompletedLine = true;
    }
    private void SkipLine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasCompletedLine && !completeLineNow && !start && !pause.isPaused)
            completeLineNow = true;
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
            yield return new WaitForSeconds(audioSource.clip.length + 5);

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
            dialogueText.text = "";
        }
    }

}
