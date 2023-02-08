using System.Collections;

using UnityEngine;

public class combinationpuzzle : MonoBehaviour
{
    public static string correctCombi = "1942";
    //not manipulating as numbers that are used operationally (+ - * /)

    public static string playerCode = "";

    public static int totalDigits = 0;

    public static string didClick = "n";

    //public GameObject enterbutton;
    
    void Start()
    {
        //enterbutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (totalDigits == 4)
            {
                if (playerCode == correctCombi)
                {
                    totalDigits = 0;
                    Debug.Log("Yay");
                }

                else if(playerCode != correctCombi)

                {
                    playerCode = "";
                    totalDigits = 0;
                    Debug.Log("No");
                }
            }
        }
    }

    void OnMouseDown()
    {
        playerCode += gameObject.name;
        totalDigits += 1;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 0);
        StartCoroutine(waitToChange());
        didClick = "y";
    }

    void OnMouseOver()
    {
        if (didClick == "n")
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    IEnumerator waitToChange()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        didClick = "n";
    }
}
