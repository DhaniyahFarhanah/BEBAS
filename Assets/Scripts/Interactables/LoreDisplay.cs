using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreDisplay : MonoBehaviour
{
    [SerializeField] GameObject eyeIndicator;
    [SerializeField] GameObject loreDisplay;
    [SerializeField] GameObject loreToOpen;
    [SerializeField] GameObject player;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject gameOver;

    PlayerStateManager playerState;

    [SerializeField] bool toOpen;

    // Start is called before the first frame update

    void Awake()
    {
        playerState = player.GetComponent<PlayerStateManager>();
    }
    void Start()
    {
        toOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toOpen && Input.GetKeyDown(KeyCode.Mouse0) && playerState.currentState != playerState.deadState && dialogueBox.activeInHierarchy == false && gameOver.activeInHierarchy == false)
        {
            ActivateLore();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toOpen = true;
            eyeIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toOpen = false;
            eyeIndicator.SetActive(false);
        }
    }

    void ActivateLore()
    {
        loreToOpen.SetActive(true);
        loreDisplay.SetActive(true);
    }
}
