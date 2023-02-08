using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class interactable : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject Z;
    public TMP_Text dialogueText;

    public Sprite itemImage;

    public string[] dialogue;
    private int index;

    private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueTypingSoundClip;
    [SerializeField] private bool stopAudioSource;

    public float wordSpeed;
    public bool playerIsClose;
    public bool start = true;

    public float speed = 1.2f; 

    public float range = 1; 

    float startingY; 

    int direction = 1;

    private void Awake()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && start == true)
        {

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }

            else
            {
                start = false;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        else if (Input.GetKeyDown(KeyCode.E) && start == false)
        {
            NextLine();
        }

        //object movement

        transform.Translate(Vector2.up * speed * Time.deltaTime * direction); //for the item to start moving 

        if (transform.position.y < startingY || transform.position.y > startingY + range) 
        {
            direction *= -1; //flip
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
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            audioSource.PlayOneShot(dialogueTypingSoundClip);
            yield return new WaitForSeconds(wordSpeed);
        }
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
            playerIsClose = true;
            Z.SetActive(true);
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
