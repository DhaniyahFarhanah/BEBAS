using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressPtoQuit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Debug.Log("esc is pressed");
        }
       
    }

    public void QuitGame()
    {

        Application.Quit();
     
    }
    
    public void ClosePanel()
    {
        panel.SetActive(false);
    }

   
}
