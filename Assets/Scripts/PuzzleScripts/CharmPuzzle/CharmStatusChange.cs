using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharmStatusChange : MonoBehaviour
{
    [SerializeField] int charmIndex;
    [SerializeField] GameObject charmPuzzle;
    [SerializeField] GameObject charmCut;
    [SerializeField] GameObject clueDialogue;
    [SerializeField] Image charmImage;
    [SerializeField] Color selectedColor;
    [SerializeField] Color notSelectedColor;

    CharmsPuzzle charm;

    // Start is called before the first frame update

    private void Awake()
    {
        charm = charmPuzzle.GetComponent<CharmsPuzzle>();
    }
    void Start()
    {
        charmImage.color = notSelectedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isHover()
    {
        charmImage.color = selectedColor;
    }

    public void isNotHover()
    {
        charmImage.color = notSelectedColor;
    }

    public void Tear()
    {
        clueDialogue.SetActive(false);
        charm.isTear[charmIndex] = true;
        charmCut.SetActive(true);
        gameObject.SetActive(false);
    }
}
