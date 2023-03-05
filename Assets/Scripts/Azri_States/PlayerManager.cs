using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver; //bool to check if game is over

    public GameObject player;
    public GameObject gameOverScreen; //game over screen

    public PlayerStateManager playerState;

    public float checkpointX;
    public float checkpointY;
    public float checkpointZ;

    private void Awake()
    {
        isGameOver = false; //game is not over by default
        playerState = player.GetComponent<PlayerStateManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            gameOverScreen.SetActive(true); //game over screen will show up when game is over
            playerState.SwitchState(playerState.deadState);
        }
        else
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void ReplayLevel() //resets the level after the user presses replay button 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Checkpoint() //Checkpoint code to spawn at a safe space
    {
        player.SetActive(true);
        player.transform.position = new Vector3(checkpointX, checkpointY, checkpointZ);
        isGameOver = false;
        playerState.SwitchState(playerState.idleState);
    }
}
