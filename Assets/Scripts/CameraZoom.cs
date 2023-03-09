using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    public GameObject player;

    PlayerStateManager state;

    [Range(1,5)]
    public float zoomSize;

    [Range(0.001f,0.1f)]
    public float zoomSpeed;

    public float setY;

    void Awake()
    {
        state = player.GetComponent<PlayerStateManager>();
    }
    void Start()
    {
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
    private void LateUpdate()
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
