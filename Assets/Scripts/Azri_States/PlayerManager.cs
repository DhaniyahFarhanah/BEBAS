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
    [SerializeField] GameObject JumpscareGO;
    [SerializeField] AudioSource clickSound;

    PlayJumpscareOnDeath jumpscare;
    Animator GameOverAnim;

    public bool death;
    public int integer;

    public PlayerStateManager playerState;

    public float checkpointX;
    public float checkpointY;
    public float checkpointZ;

    public static event Action RestartAtCheckPoint;
    private void Awake()
    {
        GameOverAnim = gameOverScreen.GetComponentInChildren<Animator>();
        jumpscare = JumpscareGO.GetComponent<PlayJumpscareOnDeath>();
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
            JumpscareGO.SetActive(true);
            playerState.currentState = playerState.deadState;
            playerState.SwitchState(playerState.deadState);
            jumpscare.PlayDeathAnim();
            isGameOver = false;
            

        }
        
    }

    public void OpenSurePanel()
    {
        clickSound.Play();
        surePanel.SetActive(true);
    }
    public void CloseSurePanel()
    {
        clickSound.Play();
        surePanel.SetActive(false);
    }
    public void OpenQuitPanel()
    {
        clickSound.Play();
        quitPanel.SetActive(true);
    }
    public void CloseQuitPanel()
    {
        clickSound.Play();
        quitPanel.SetActive(false);
    }
    public void OpenMenuPanel()
    {
        clickSound.Play();
        menuPanel.SetActive(true);
    }
    public void CloseMenuPanel()
    {
        clickSound.Play();
        menuPanel.SetActive(false);
    }

    public void ReplayLevel() //resets the level after the user presses replay button 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerState.SwitchState(playerState.idleState);
        isGameOver = false;
    }

    public void Checkpoint() //Checkpoint code to spawn at a safe space
    {
        if (!clickSound.isPlaying)
        {
            clickSound.Play();
        }

        player.SetActive(true);
        player.transform.position = new Vector3(checkpointX, checkpointY, checkpointZ);
        playerState.SwitchState(playerState.idleState);

        playerState.currentState = playerState.idleState;
        playerState.SwitchState(playerState.idleState);
        JumpscareGO.SetActive(false);
        isGameOver = false;

        StartCoroutine(StartFadeCoroutine());
        GameOverAnim.SetBool("Replay", true);

        // calls an event that the player has restarted to the checkpoint;
        RestartAtCheckPoint?.Invoke();
    }

    IEnumerator StartFadeCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        GameOverAnim.SetBool("Replay", false) ;
        gameOverScreen.SetActive(false);
    }
}
