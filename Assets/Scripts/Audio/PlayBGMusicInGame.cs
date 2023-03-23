using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGMusicInGame : MonoBehaviour
{
    [SerializeField] AudioClip OutsideBGM;
    [SerializeField] AudioClip InsideBGM;
    [SerializeField] AudioClip EndGameChaseBGM;
    [SerializeField] AudioSource BGMsource;

    [SerializeField] GameObject CheckInWard;
    [SerializeField] GameObject CheckEndGame;

    [SerializeField] GameObject pause;
    [SerializeField] GameObject jumpscare;

    CheckAgroCryingScript inside;

    bool isOutside;
    bool isInside;
    bool isEndGame;
    // Start is called before the first frame update
    private void Awake()
    {
        inside = CheckInWard.GetComponent<CheckAgroCryingScript>();
    }
    void Start()
    {
        isOutside = true;
        BGMsource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(pause.activeInHierarchy || jumpscare.activeInHierarchy)
        {
            BGMsource.Stop();
        }
        else
        {
            if (!BGMsource.isPlaying)
            {
                BGMsource.Play();
            }
        }

        CheckConditions();

        if (isOutside)
        {
            BGMsource.clip = OutsideBGM;
        }
        else if (isInside)
        {
            BGMsource.clip = InsideBGM;
        }
        else if (isEndGame)
        {
            BGMsource.clip = EndGameChaseBGM;
        }
    }

    public void CheckConditions()
    {
        if (CheckEndGame.activeInHierarchy)
        {
            isEndGame = true;
            isOutside = false;
            isInside = false;
        }

        if (inside.inWard)
        {
            isEndGame = false;
            isOutside = false;
            isInside = true;
        }
        else
        {
            isEndGame = false;
            isOutside = true;
            isInside = false;
        }
    }
}
