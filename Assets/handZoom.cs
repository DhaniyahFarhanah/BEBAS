using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handZoom : MonoBehaviour
{
    Animator handAnim;
    // Start is called before the first frame update
    void Start()
    {
        handAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            handAnim.SetBool("Start", true);
        }
    }
}