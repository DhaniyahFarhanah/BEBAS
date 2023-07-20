using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdBreathGhost : MonoBehaviour
{
    //Script done by Avian (koko)
    //Script modified by Dhaniyah Farhanah Binte Yusoff
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "holdBreathGhost" && Input.GetKey(KeyCode.Space) == true) //if the player collides with objects with the tag "ghost"
        {
            PlayerManager.isGameOver = false; //game is over is true
        }

        else if (collision.transform.tag == "holdBreathGhost" && Input.GetKey(KeyCode.Space) == false)
        {
            CatchPlayer();
        }
    }
    private void CatchPlayer()
    {
        // If player close eyes, player lives, otherwise, dies
        //PlayerStateManager playerState = Player.GetComponent<PlayerStateManager>();
        Transform Player = null;
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform; if (Player == null) Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerStateManager playerState = Player.gameObject.GetComponent<PlayerStateManager>();
        switch (playerState.currentState)
        {
            case PlayerHoldBreathState:
                Debug.Log("Let player live");
                break;
            default:
                Debug.Log("Kill Player!");

                PlayerManager.isGameOver = true;
                gameObject.SetActive(false);
                break;
        }

    }
}
