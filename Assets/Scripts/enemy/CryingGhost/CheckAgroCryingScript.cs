using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAgroCryingScript : MonoBehaviour
{

    public bool justEntered = true;
    public bool inWard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inWard = true;
            justEntered = true;
            StartCoroutine(waitforkill());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            justEntered = false;
        }
      
    }

    IEnumerator waitforkill()
    {
        yield return new WaitForSeconds(5f);
        justEntered = false;
    }
}
