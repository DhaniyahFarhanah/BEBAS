using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonstuff : MonoBehaviour
{
    [SerializeField] AudioSource chime;
    [SerializeField] GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsSelected()
    {
        chime.Play();
        arrow.SetActive(true);
    }

    public void IsNotSelected()
    {
        arrow.SetActive(false);
    }
}
