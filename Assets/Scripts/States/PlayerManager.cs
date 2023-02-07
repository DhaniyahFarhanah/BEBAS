using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver; //bool to check if game is over

    public GameObject gameOverScreen; //game over screen

    private void Awake() 
    {
        isGameOver = false; //game is not over by default
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true); //game over screen will show up when game is over
        }
    }

    public void ReplayLevel() //resets the level after the user presses replay button 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
