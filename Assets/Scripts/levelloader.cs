using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public Animator transition; //animator for transition

    public float transitionTime = 1f; //transition time is about 1f

    // Update is called once per frame
    void Update()
    {
        //if user clicks on mouse
        if (Input.GetMouseButtonDown(0)){ 
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){ // create coroutines

        //play animation

        transition.SetTrigger("Start");

        //wait

        yield return new WaitForSeconds(transitionTime); //pauses coroutine for x amount of seconds 

        //load scene

        SceneManager.LoadScene(levelIndex);

    } 
}
