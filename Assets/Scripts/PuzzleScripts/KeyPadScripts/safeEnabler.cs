using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeEnabler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject puzzle;
    [SerializeField] GameObject openSafe;
    [SerializeField] GameObject closeSafe;

    public void Enable()
    {
        openSafe.SetActive(true);
        closeSafe.SetActive(false);
        player.SetActive(true);
        puzzle.SetActive(false);
    }
}
