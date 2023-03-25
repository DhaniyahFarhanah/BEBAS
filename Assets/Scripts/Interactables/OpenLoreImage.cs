using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLoreImage : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject[] allLores;


    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            Time.timeScale = 0;
        }

        if(gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;

            for (int i = 0; i < allLores.Length; i++)
            {
                allLores[i].SetActive(false);
            }

            gameObject.SetActive(false);
        }

        
    }

    public void closeLore()
    {
        if (gameObject.activeInHierarchy)
        {
            Time.timeScale = 1;

            for (int i = 0; i < allLores.Length; i++)
            {
                allLores[i].SetActive(false);
            }

            gameObject.SetActive(false);

        }
        

        
    }


}
