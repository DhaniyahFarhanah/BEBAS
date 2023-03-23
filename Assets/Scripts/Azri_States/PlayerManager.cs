using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver; //bool to check if game is over

    public GameObject player;
    public GameObject gameOverScreen; //game over screen
    [SerializeField] GameObject surePanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject quitPanel;
    [SerializeField] GameObject jumpscareHUD;
    [SerializeField] Animator Jumpscareanimator;

    public bool death;
    public int integer;

    public PlayerStateManager playerState;

    public float checkpointX;
    public float checkpointY;
    public float checkpointZ;

    public static event Action RestartAtCheckPoint;
    private void Awake()
    {
        isGameOver = false; //game is not over by default
        playerState = player.GetComponent<PlayerStateManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpointX = player.transform.position.x;
        checkpointY = player.transform.position.y;
        checkpointZ = player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {

            jumpscareHUD.SetActive(true);
            Jumpscareanimator.SetBool("Death", death);
            Jumpscareanimator.SetInteger("Type", integer);
            StartCoroutine(Jumpscare());


        }
        else
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void OpenSurePanel()
    {
        surePanel.SetActive(true);
    }
    public void CloseSurePanel()
    {
        surePanel.SetActive(false);
    }
    public void OpenQuitPanel()
    {
        quitPanel.SetActive(true);
    }
    public void CloseQuitPanel()
    {
        quitPanel.SetActive(false);
    }
    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
    }
    public void CloseMenuPanel()
    {
        menuPanel.SetActive(false);
    }

    public void ReplayLevel() //resets the level after the user presses replay button 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerState.SwitchState(playerState.idleState);
        jumpscareHUD.SetActive(false);
        isGameOver = false;
    }

    public void Checkpoint() //Checkpoint code to spawn at a safe space
    {
        player.SetActive(true);
        player.transform.position = new Vector3(checkpointX, checkpointY, checkpointZ);
        isGameOver = false;
        playerState.SwitchState(playerState.idleState);

        // calls an event that the player has restarted to the checkpoint;
        RestartAtCheckPoint?.Invoke();
    }
    IEnumerator Jumpscare()
    {
        yield return null;
        jumpscareHUD.SetActive(false);
        playerState.SwitchState(playerState.deadState);
        gameOverScreen.SetActive(true); //game over screen will show up when game is over
    }
}
