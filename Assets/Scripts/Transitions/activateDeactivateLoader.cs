using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateDeactivateLoader : MonoBehaviour
{
    [SerializeField] GameObject loader;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.activeInHierarchy)
        {
            loader.SetActive(false);
        }
        else
        {
            loader.SetActive(true);
        }
    }
}
