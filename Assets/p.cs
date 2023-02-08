using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p : MonoBehaviour
{
    private void Awake()
    {
        //do whatever

        DontDestroyOnLoad(this);
    }
}
