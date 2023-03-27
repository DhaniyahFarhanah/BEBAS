using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateMove : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    //this is a shit ass way to do it but it works for now

    public Button[] gateArray;
    public GameObject fenceOpen;
    public GameObject bolt;

    public AudioSource gatesound;
    bool playOncedone;
    bool playOncetwo;


    public GameObject player;
    public GameObject gateClosed;
    public GameObject gateOpened;
    public GameObject Puzzle;

    Animator animator;

    int count;

    private void Awake()
    {
        animator = fenceOpen.GetComponent<Animator>();
    }
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;

        foreach (var gate in gateArray)
        {
            if (gate.interactable == false)
            {
                count++;
                continue;
            }

            
        }

        if (count == 11)
            {
                Debug.Log("finished");
                StartCoroutine(ReturnGameplayScene());
            }
            else
            {
                Debug.Log("not finished");
            }

    }

    public void playAnim()
    {
        //here will have anims but for now just disable the boltcutter;
        bolt.SetActive(false);
    }

    IEnumerator ReturnGameplayScene()
    {
        
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Open");
        if (!gatesound.isPlaying && !playOncetwo)
        {
            gatesound.Play();
            playOncetwo = true;

        }
        yield return new WaitForSeconds(1f);
        
        Puzzle.SetActive(false);
        player.SetActive(true);
        gateClosed.SetActive(false);
        gateOpened.SetActive(true);
    }

    
}
