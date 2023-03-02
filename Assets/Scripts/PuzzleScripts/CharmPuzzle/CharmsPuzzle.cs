using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CharmsPuzzle : MonoBehaviour
{
    [SerializeField] GameObject keyholeScript;
    public bool[] isTear;
    [SerializeField] bool canUnlock;

    KeyholeScript keyhole;

    int index;

    void Awake()
    {
        keyhole = keyholeScript.GetComponent<KeyholeScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        if (canUnlock)
        {
            keyhole.canUnlock = true;
        }
    }

    void CheckStatus()
    {
        int count = 0;

        foreach(bool v in isTear)
        {
            if (v == true)
            {
                count++;
            }
        }

        if (count == isTear.Length)
        {
            canUnlock = true;
        }
        else
        {
            canUnlock = false;
        }
    }

}
