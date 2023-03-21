using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyholeCanUnlock : MonoBehaviour
{
    [SerializeField] GameObject eyeClue;
    [SerializeField] Color selected;
    [SerializeField] Color notSelected;
    [SerializeField] GameObject thisPuzzle;
    [SerializeField] GameObject doorOutsideOpened;
    [SerializeField] GameObject doorOutsideClosed;
    [SerializeField] GameObject player;
    //[SerializeField] bool keyInside;

    //will change to anims once done
    [SerializeField] Sprite KeyisInside;
    [SerializeField] Sprite KeyTurn;
    [SerializeField] GameObject DoorOpen;

    bool playOnce;
    bool playOnceTurn;
    bool doorOpenPlayOnce;
    Image keyhole;
    bool eyeshow;

    [SerializeField] int clickIndex;
    [SerializeField] private AudioSource keyIn;
    [SerializeField] private AudioSource keyTurn;
    [SerializeField] AudioSource doorOpen;
    void Start()
    {
        keyhole = GetComponent<Image>();
        eyeshow = false;
        playOnce = false;
        playOnceTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeshow)
        {
            eyeClue.SetActive(true);
        }
        else
        {
            eyeClue.SetActive(false);
        }

        if (clickIndex == 1)
        {
            //key inside
            if (!keyIn.isPlaying && !playOnce)
            {
                keyIn.Play();
                playOnce = true;
            }
         
            keyhole.sprite = KeyisInside;

            
        }

        if (clickIndex >= 2)
        {
            //unlockDoor
            keyhole.sprite = KeyTurn;
            if (!keyTurn.isPlaying && !playOnceTurn)
            {
                keyTurn.Play();
                playOnceTurn = true;
            }
            
            StartCoroutine(UnlockDoor());
        }
    }
    public void OnHover()
    {
        keyhole.color = selected;
        if(clickIndex < 1)
        {
            eyeshow = true;

        }
        else
        {
            eyeshow = false;
        }
    }

    public void OnNotHover()
    {
        keyhole.color = notSelected;
        eyeshow = false;
    }

    public void click()
    {
        clickIndex++;
        eyeshow = false;
    }

    IEnumerator UnlockDoor()
    {
        keyhole.sprite = KeyTurn;
        if (!doorOpenPlayOnce)
        {
            doorOpen.Play();
            doorOpenPlayOnce = true;
        }
        
        yield return new WaitForSeconds(1f);
        DoorOpen.SetActive(true);
        yield return new WaitForSeconds(1f);
        player.SetActive(true);
        doorOutsideClosed.SetActive(false);
        doorOutsideOpened.SetActive(true);
        thisPuzzle.SetActive(false);
    }

}
