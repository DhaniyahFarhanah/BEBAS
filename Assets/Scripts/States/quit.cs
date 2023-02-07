using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
    public GameObject QuitMenu;

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        QuitMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //if user presses P
        {
            if (isPaused)
            {
               StayGame();
            }
            else
            {
                GoToMainMenu();
            }
        }
    }

    public void StayGame()
    {
        QuitMenu.SetActive(false); //menu is active when button is pressed
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
