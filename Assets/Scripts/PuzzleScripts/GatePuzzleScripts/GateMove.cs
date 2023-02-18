using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateMove : MonoBehaviour
{
    //this is a shit ass way to do it but it works for now

    public Button[] gateArray;

    public GameObject player;
    public GameObject gateClosed;
    public GameObject gateOpened;
    public GameObject Puzzle;

    public SpriteRenderer Background;

    public RawImage image;

    int count;

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
                image.CrossFadeAlpha(0, 0.3f, true);
                StartCoroutine(ReturnGameplayScene());
            }
            else
            {
                Debug.Log("not finished");
            }

    }

    IEnumerator ReturnGameplayScene()
    {
        yield return new WaitForSeconds(1f);
        
        Puzzle.SetActive(false);
        player.SetActive(true);
        gateClosed.SetActive(false);
        gateOpened.SetActive(true);
    }

    
}
