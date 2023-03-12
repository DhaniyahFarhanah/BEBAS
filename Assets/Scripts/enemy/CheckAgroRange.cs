using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAgroRange : MonoBehaviour
{
    public bool canAgro;
    public bool noImmediateKill;
    public bool isCrawling;

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
            canAgro = true;
            StartCoroutine(waitForKill()); 
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canAgro = true;
            if (isCrawling)
            {
                noImmediateKill = false;
            }
            else
            {
                noImmediateKill = true;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canAgro = false;
            noImmediateKill = false;
        }
    }

    IEnumerator waitForKill()
    {
        yield return new WaitForSeconds(2f);
        noImmediateKill = true;
    }
}
