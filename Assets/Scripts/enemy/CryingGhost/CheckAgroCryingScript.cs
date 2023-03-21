using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAgroCryingScript : MonoBehaviour
{

    public bool justEntered = true;
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
        yield return new WaitForSeconds(4f);
        justEntered = false;
    }
}
