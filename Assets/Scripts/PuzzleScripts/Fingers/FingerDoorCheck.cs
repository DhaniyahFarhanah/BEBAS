using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerDoorCheck : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject player;
    [SerializeField] GameObject itsLocked;

    PlayerCheckPickUpFinger fingerCount;
    DoorEnterScript door;
    InstructionScript W;
    public bool isLocked;

    // Start is called before the first frame update
    private void Awake()
    {
        fingerCount = player.GetComponent<PlayerCheckPickUpFinger>();
        door = gameObject.GetComponent<DoorEnterScript>();
        W = gameObject.GetComponent<InstructionScript>();
    }
    void Start()
    {
        door.enabled = false;
        isLocked = true;
        W.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked)
        {
            door.enabled = true;
            itsLocked.SetActive(false);
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                itsLocked.SetActive(true);
            }
            door.enabled = false;
            
        }

    }

    void CheckFinger()
    {
        if(fingerCount.Count == 4)
        {
            isLocked = false;
            door.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                CheckFinger();

        }
    }
}
