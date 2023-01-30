using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public float delay;

    //awake
    private void Awake()
    {
        //set resolution
        Screen.SetResolution(1920, 1080, false);

        //init persistance objects
        InitObj();

        //start loading process
        StartCoroutine(LoadApp());
    }

    private IEnumerator LoadApp()
    {
        //delay
        yield return new WaitForSeconds(delay);

        //load main menu scene
        StateManager.Instance.SwitchSceneTo("Menu");
    }

    //init objects that persist trhoughout scenes
    private void InitObj()
    {
        if (StateManager.Instance) { };
    }
}
