using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableScript : MonoBehaviour
{
    [SerializeField] GameObject[] toBeEnabled;
    [SerializeField] GameObject[] toBeDisabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(toBeEnabled.Length >= 1) 
        { 
            for(int i = 0; i < toBeEnabled.Length; i++)
            {
                toBeEnabled[i].SetActive(true);
            }
        
        }

        if(toBeDisabled.Length >= 1)
        {
            for(int i = 0; i < toBeEnabled.Length; i++)
             {
                toBeDisabled[i].SetActive(false);
            }

        }
    }
}
