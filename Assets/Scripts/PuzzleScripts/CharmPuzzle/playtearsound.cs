using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playtearsound : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] AudioSource papertearsound;
    // Start is called before the first frame update
    void Start()
    {
        papertearsound.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
