using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleDialogueScript : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject Z;
    public GameObject gameObject_this;
    public GameObject puzzle;
    public GameObject player;

    public Image display;
    public Sprite newImage;
    public TMP_Text dialogueText;

    public string[] dialogue;
    [SerializeField] private int index;
    [SerializeField] private bool hasCompletedLine = false;
    private bool completeLineNow = false;

    public float wordSpeed;
    public float currentWordSpeed;
    public bool playerIsClose;
    public bool start = true;

    [SerializeField] private bool showAfterDialogue;
    private bool showingPreDialogueNow;
    [SerializeField] private int showAfterDialogueIndex;
    private bool showingDialogueNow = false;

    [SerializeField] private bool puzzleCompleted;

    private AudioSource audioSource;
    [SerializeField] private AudioClip walkingSoundClip;
    [SerializeField] private bool stopAudioSource;
    [SerializeField] private bool interactable;

    private void Awake()
    {
        wordSpeed = 0.03f;
        currentWordSpeed = wordSpeed;
        audioSource = gameObject.AddComponent<AudioSource>();
        if (!showAfterDialogue)
        {
            showAfterDialogueIndex = dialogue.Length;
        }

    }

    // Update is called once per frame
    void Update()
    {
        SkipLine();
        // Otherwise player can keep on pressing and can hear that it is typing

        if (puzzle.activeSelf == true)
        {
            // Show dialog here
            if (!showingPreDialogueNow)
            {
              showingPreDialogueNow = true;
              start = false;
              dialoguePanel.SetActive(true);
              index = 0;
              StartCoroutine(Typing());
            }
            if (dialoguePanel.activeSelf == true)
            {
              if (Input.GetKeyDown(KeyCode.Mouse0) && hasCompletedLine)
              {
                if (index + 1 == showAfterDialogueIndex)
                {
                   zeroText();
                   index = showAfterDialogueIndex;
                }
                NextLine();
              }
            }
            
            // Check if game completed here
            if (puzzle.GetComponent<FuseBoxPuzzleScript>())
            {
                if (puzzle.GetComponent<FuseBoxPuzzleScript>().lightsOn)
                {
                    puzzleCompleted = true;
                    interactable = false;   // Once puzzle completed, this puzzle dont have to be interactable anymore, we dont want player to touch it

                    //ShowAfterPuzzleDialogue();
                }
            }

            // If puzzle is active, dont need to run the remaining code in this method, so just return and stop it here
            return;
        }


        // If puzzle is not active and showing predialogue now, zeroText()
        // Will come to this line of code WHEN user press ESC after clicking on puzzle dialogue
        if (puzzle.activeSelf == false && showingPreDialogueNow && !puzzleCompleted)
        {
            showingPreDialogueNow = false;
            zeroText();
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && playerIsClose && start == true)
        {

            Debug.Log("Interact");
            if ((dialogue.Length == 0 || !showAfterDialogue) && interactable && !puzzleCompleted)
            {
                Debug.Log("puzzle1");

                StartCoroutine(SwitchPuzzleImmediate());

            }

            else if (dialoguePanel.activeInHierarchy)
            {
                zeroText();

            }
            else if (showAfterDialogue && !puzzleCompleted && interactable)
            {
                Debug.Log("puzzle2");

                StartCoroutine(SwitchPuzzleImmediate());
            }

            else
            {
                if (interactable)
                {
                    start = false;
                    dialoguePanel.SetActive(true);
                    index = 0;
                    StartCoroutine(Typing());
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && start == false && hasCompletedLine)
        {
            NextLine();
        }


    }

    /*private void ShowAfterPuzzleDialogue()
    {
        if (puzzleCompleted && !showingDialogueNow)
        {
            start = false;
            dialoguePanel.SetActive(true);
            index = showAfterDialogueIndex;
            showingDialogueNow = true;
            StartCoroutine(Typing());
        }
    }*/

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        start = true;

        dialoguePanel.SetActive(false);
        StopAllCoroutines();
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            yield return new WaitForSeconds(currentWordSpeed);

            hasCompletedLine = false;
            dialogueText.text += letter;
            if (stopAudioSource)
            {
                audioSource.Stop();
            }
            audioSource.PlayOneShot(walkingSoundClip);

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
            int nextIndex = index + 1;
            if (nextIndex < showAfterDialogueIndex || puzzleCompleted)
            {
                index++;

                dialogueText.text = "";
                StartCoroutine(Typing());
            }
        }
        else
        {
            zeroText();
            //StartCoroutine(SwitchPuzzleScene());
        }
    }

    IEnumerator SwitchPuzzleImmediate()
    {
        puzzle.SetActive(true);
        player.SetActive(false);
        yield return null;
    }
    IEnumerator SwitchPuzzleScene()
    {
        puzzle.SetActive(true);
        player.SetActive(false);
        yield return null;

    }

    private void OnTriggerEnter2D(Collider2D interact)
    {
        if (interact.CompareTag("Player"))
        {
            playerIsClose = true;
            Z.SetActive(true);
            display.sprite = newImage;
            if (newImage == null)
            {
                display.gameObject.SetActive(false);
            }

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
