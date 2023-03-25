using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    public GameObject visuals;
    public GameObject sensor;
    public GameObject player;


    private void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D sensor)
    {
        if (sensor.CompareTag("Player"))
        {
            visuals.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D sensor)
    {
        if (sensor.CompareTag("Player"))
        {
            visuals.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D sensor)
    {
        if (sensor.CompareTag("Player"))
        {
            visuals.SetActive(false);
        }
    }
}
