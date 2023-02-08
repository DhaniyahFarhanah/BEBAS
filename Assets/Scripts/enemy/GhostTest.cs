using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTest : MonoBehaviour
{
    private SpriteRenderer ghostRenderer;
    public Color oldColor;
    public Color newColor;


    // Start is called before the first frame update
    void Start()
    {
        ghostRenderer = GetComponent<SpriteRenderer>();
        ghostRenderer.color = oldColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ghostRenderer.color = newColor;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ghostRenderer.color = oldColor;
        }
    }
}
