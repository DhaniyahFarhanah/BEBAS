using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartingZoomOut : MonoBehaviour
{
    private Camera cam;
    public GameObject player;
    CameraZoom cameraZoomScript;


    [Range(1, 5)]
    public float zoomSize;

    public float zoomSpeed;

    bool isSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ZoomOut()
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, zoomSpeed);
    }
}
