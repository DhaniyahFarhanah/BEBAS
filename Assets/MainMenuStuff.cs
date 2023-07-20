using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStuff : MonoBehaviour
{
    [SerializeField] GameObject areyousure;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitButtonPress()
    {
        areyousure.SetActive(true);
    }

    public void closePanel()
    {
        areyousure.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
