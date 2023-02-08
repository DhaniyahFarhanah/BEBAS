using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    //awake
    private void Awake()
    {
        //set resolution
        Screen.SetResolution(1920, 1080, false);

        //init persistance objects
        InitObj();

        //start loading process
    }

    private void Update()
    {

    }

    

    private IEnumerator LoadApp()
    {
        //delay
        yield return new WaitForSeconds(3);

        //load main menu scene
        StateManager.Instance.SwitchSceneTo("Gameplay_Alpha");
    }
    
    public void startTransition()
    {
        StartCoroutine("LoadApp");
    }

    //init objects that persist trhoughout scenes
    private void InitObj()
    {
        if (StateManager.Instance) { };
    }
}
