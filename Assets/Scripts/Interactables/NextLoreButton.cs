using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLoreButton : MonoBehaviour
{
    [SerializeField] GameObject[] lorePages;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject prevButton;

    int loretobeactiveIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (loretobeactiveIndex == 0)
        {
            prevButton.SetActive(false);
        }
        else if (loretobeactiveIndex == lorePages.Length - 1)
        {
            nextButton.SetActive(false);
        }
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
        }


    }

    public void NextLore()
    {
        loretobeactiveIndex++;

        for (int i = 0; i < lorePages.Length; i++)
        {
            if (i == loretobeactiveIndex)
            {
                lorePages[i].SetActive(true);
            }
            else
            {
                lorePages[i].SetActive(false);
            }
        }
    }
    
    public void PrevLore()
    {
        loretobeactiveIndex--;

        for (int i = 0; i < lorePages.Length; i++)
        {
            if (i == loretobeactiveIndex)
            {
                lorePages[i].SetActive(true);
            }
            else
            {
                lorePages[i].SetActive(false);
            }
        }
    }

}
