using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFingerCollect : MonoBehaviour
{
    public bool[] isAttached;

    public bool isComplete;
    [SerializeField] GameObject torturedGhost;
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject puzzleNotDone;
    [SerializeField] GameObject puzzleDone;
    [SerializeField] GameObject player;
    [SerializeField] GameObject fingerHUD;

    bool twitchDone = false;

    // Start is called before the first frame update
    void Start()
    {
        twitchDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckFingers();

        if (isComplete && twitchDone == false)
        {
            //do complete
            StartCoroutine(closePuzzle());
        }
    }

    public void CheckFingers()
    {
        int count = 0;

        foreach(bool v in isAttached)
        {
            if(v == true)
            {
                count++;
            }
        }

        if(count == isAttached.Length)
        {
            isComplete = true;
        }

        else
        {
            isComplete = false;
        }
    }

    IEnumerator closePuzzle()
    {
        yield return new WaitForSeconds(1f);
        //have finger twitch
        torturedGhost.SetActive(true);
        player.SetActive(true);
        puzzleDone.SetActive(true);
        puzzleNotDone.SetActive(false);
        fingerHUD.SetActive(false);
        puzzle.SetActive(false);
        
    }
}
