using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    [SerializeField] Animator handAnim;
    //awake
    private void Awake()
    {
     
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
        handAnim.SetBool("Start", true);

        //load main menu scene
        StateManager.Instance.SwitchSceneTo("Gameplay_Alpha");
    }
    
    public void startTransition()
    {
        StartCoroutine(LoadApp());
    }

    //init objects that persist trhoughout scenes
    private void InitObj()
    {
        if (StateManager.Instance) { };
    }
}
