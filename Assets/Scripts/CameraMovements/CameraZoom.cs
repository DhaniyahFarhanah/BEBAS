using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraZoom : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    private Camera cam;
    public GameObject player;

    public GameObject spawnDialogue;
    public GameObject dialoguePanel;
    public GameObject moveInstructions;
    public GameObject HUD;

    PlayerStateManager state;
    CameraFollow camerafollowScript;

    [Range(1,5)]
    public float zoomSize;

    [Range(0.001f,0.1f)]
    public float zoomSpeed;

    public float spawnZoomSpeed;

    public float setY;

    public bool isSpawn;


    void Awake()
    {
        state = player.GetComponent<PlayerStateManager>();
        camerafollowScript = gameObject.GetComponent<CameraFollow>();
    }
    void Start()
    {
        isSpawn = true;
        cam = Camera.main;
        gameObject.transform.position = cam.transform.position;
        
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void zoomCamera()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,zoomSize, zoomSpeed);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + setY , gameObject.transform.position.z);
    }
    void zoomOut()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,5,zoomSpeed);
    }

    void spawnZoomOut()
    {
        cam.orthographicSize = Mathf.Lerp (cam.orthographicSize,3,spawnZoomSpeed);
        //gameObject.transform.position = new Vector3(Mathf.Lerp(-11.61f, -6f, spawnZoomSpeed), Mathf.Lerp(2.15f, 0.3061578f, spawnZoomSpeed), gameObject.transform.position.z);
        
    }
    private void LateUpdate()
    {
        if (isSpawn)
        {
            StartCoroutine(WaitforZoomSpawn());

            

            if(cam.orthographicSize > 2.5f)
            {

                if (!dialoguePanel.activeInHierarchy)
                {
                    camerafollowScript.enabled = true;
                    state.enabled = true;
                    moveInstructions.SetActive(true);
                    HUD.SetActive(true);
                    isSpawn = false;
             

                }
                else
                {
                    
                }
            }
            
        }
        else
        {

            if (state.currentState == state.eyesState)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    zoomCamera();
                }
           
            }
            else
            {
                zoomOut();
            }

        }

       
    }

    IEnumerator WaitforZoomSpawn()
    {
        yield return new WaitForSeconds(2f);
        spawnDialogue.SetActive(true);
        spawnZoomOut();
    }
}
