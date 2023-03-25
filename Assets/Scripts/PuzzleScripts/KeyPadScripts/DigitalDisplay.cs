using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalDisplay : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject door;
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject display;
    [SerializeField] GameObject player;
    [SerializeField] GameObject puzzleComplete;
    [SerializeField] GameObject puzzleNotComplete;

    public bool playAnim;
    public bool isCorrect;
    public bool isWrong;

    [SerializeField] bool safe;

    [SerializeField]
    private Sprite[] digits;

    [SerializeField]
    private Sprite[] correct;

    [SerializeField]
    private Image[] characters;

    [SerializeField]
    private string correctCombi;

    [SerializeField]
    private bool enableplayer;

    private string codeSequence;

    exitPuzzle script;

    [SerializeField] private AudioSource wrongInputAudio;
    [SerializeField] private AudioSource correctInputAudio;

    private void Awake()
    {
        script = puzzle.GetComponent<exitPuzzle>();
    }
    void Start()
    {
        codeSequence = "";
        script.canClose = true;
        Debug.Log(this.gameObject.name + " is HAHAHAHA");
        for (int i = 0; i <= characters.Length -1; i++)
        {
            characters[i].sprite = digits[10];
        }
        if (safe)
        {
            KeyButtonPress2.ButtonPressed2 += AddDigitToCodeSequence;
        }
        else
        {
            KeyButtonPress.ButtonPressed += AddDigitToCodeSequence;
        }
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if(codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "Zero":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;
                case "One":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;
                case "Two":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;
                case "Three":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;
                case "Four":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;
                case "Five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;
                case "Six":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;
                case "Seven":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;
                case "Eight":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;
                case "Nine":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
            }
        }
        if(codeSequence.Length == 4)
        {
            CheckResults();
        }

    }

    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = digits[10];
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 2:
                characters[0].sprite = digits[10];
                characters[1].sprite = digits[10];
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 3:
                characters[0].sprite = digits[10];
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
        }
    }

    private void CheckResults()
    {
        playAnim = true;

        if (codeSequence == correctCombi)
        {
            Debug.Log("Correct");
            isCorrect = true;
            isWrong = false;
            script.canClose = false;
            characters[0].sprite = correct[0];
            characters[1].sprite = correct[1];
            characters[2].sprite = correct[2];
            characters[3].sprite = correct[3];
            correctInputAudio.Play();
            StartCoroutine(Correct());
        }

        else
        {
            isCorrect = false;
            isWrong = true;
            Debug.Log("Wrong");
            wrongInputAudio.Play();
            StartCoroutine(Wrong());
        }
    }

    private void ResetDisplay()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].sprite = digits[10];
        }
        codeSequence = "";
    }


    private void OnDestroy()
    {
        KeyButtonPress.ButtonPressed -= AddDigitToCodeSequence;
        KeyButtonPress2.ButtonPressed2 -= AddDigitToCodeSequence;
    }
    IEnumerator Correct()
    {
        yield return new WaitForSeconds(1f);
        
        codeSequence = "";
       
        door.SetActive(true);
        puzzle.SetActive(false);
        display.SetActive(false);
        puzzleNotComplete.SetActive(false);
        puzzleComplete.SetActive(true);
        if (enableplayer)
        {
        player.SetActive(true);

        }

    }

    IEnumerator Wrong()
    {
        yield return new WaitForSeconds(0.5f);
        ResetDisplay();
    }
}
