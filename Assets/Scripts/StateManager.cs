using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//from john quick lol
public class StateManager : MonoBehaviour
{
    //singleton instance

    private static StateManager _Instance;

    //singleton accessor
    //access StateManager.Instance from other classes
    public static StateManager Instance
    {
        //create instance via getter (manipulate private variable to some extent)
        get
        {
            //get existing instance
            //if no instance
            if(_Instance == null)
            {
                //create game object
                GameObject StateManagerObj = new GameObject();
                StateManagerObj.name = "StateManager";

                //create instance
                _Instance = StateManagerObj.AddComponent<StateManager>();
            }

            //return instance
            return _Instance;
        }
    }
    
    //awake -> Starts/runs First
    void Awake()
    {
        //prevent this script from being destroyed.
        DontDestroyOnLoad(this);
    }

    //switch scene by name
    public void SwitchSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
