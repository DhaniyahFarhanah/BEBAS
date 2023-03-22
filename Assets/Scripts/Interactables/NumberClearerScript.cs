using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberClearerScript : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite Outline;
    [SerializeField] Sprite NoOutline;
    [SerializeField] GameObject safeDone;
    private void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
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
        if (!safeDone.activeInHierarchy)
        {
            sr.sprite = Outline;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.sprite = NoOutline;
    }
}
