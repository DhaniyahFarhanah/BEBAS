using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject PauseMenu; //ref to pause menu 

    public static bool isPaused; //global variable so that inputs from other scripts will stop when game is paused

    void Start()
    {
        PauseMenu.SetActive(false); //menu is not active by default
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //if user presses P
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true); //menu is active when button is pressed
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void ResumeGame()
    {
        PauseMenu.SetActive(false); //menu is active when button is pressed
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainscreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
