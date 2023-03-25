using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeEnabler : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject player;
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject openSafe;
    [SerializeField] GameObject closeSafe;
    [SerializeField] AudioSource Key;

    public void Enable()
    {
        
        openSafe.SetActive(true);
        closeSafe.SetActive(false);
        player.SetActive(true);
        puzzle.SetActive(false);
    }
    public void playSound()
    {
        Key.Play();
    }
}
