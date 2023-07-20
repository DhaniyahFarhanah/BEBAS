using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetJumpscare: MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject jumpscareHud;
    [SerializeField] int type;
    [SerializeField] float waitTime;
    [SerializeField] AudioClip jumpscareSound;

    public bool KilledPlayer;
    PlayJumpscareOnDeath jumpscare;
    private void Awake()
    {
        jumpscare = jumpscareHud.GetComponent<PlayJumpscareOnDeath>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KilledPlayer = true;
            jumpscare.AnimIndex = type;
            jumpscare.jumpscareWaitSeconds = waitTime;
            jumpscare.jumpscareSound = jumpscareSound;

        }
    }
}
