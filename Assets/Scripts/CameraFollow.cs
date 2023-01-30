using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax); //mathclamp gets player position and allows player to be between xmin and xmax.
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z); //set default z
    }
}
