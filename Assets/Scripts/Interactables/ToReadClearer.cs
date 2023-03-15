#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class ToReadClearer : MonoBehaviour
{
    [SerializeField] GameObject overlay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !overlay.activeInHierarchy)
        {
            overlay.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && overlay.activeInHierarchy)
        {
            overlay.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            overlay.SetActive(false);
        }
    }
}
#endif