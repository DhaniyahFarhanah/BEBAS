using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudFingerShow : MonoBehaviour
{
    Image finger;
    Color hasFinger = new Color(255,255,255);
    Color noFinger = new Color(0,0,0);

    PlayerCheckPickUpFinger fingerCheck;

    [SerializeField] int index;
    // Start is called before the first frame update

    private void Awake()
    {
        finger = gameObject.GetComponent<Image>();
        fingerCheck = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCheckPickUpFinger>();
    }
    void Start()
    {
        finger.color = noFinger;
    }

    // Update is called once per frame
    void Update()
    {
        if (fingerCheck.HasFinger[index] == true)
        {
            finger.color = hasFinger;
        }
    }
}
