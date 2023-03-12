using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWardEndGame : MonoBehaviour
{
    [SerializeField] GameObject tortured;

    FollowPlayerScript azriWardCheck;

    private void Awake()
    {
        azriWardCheck = tortured.GetComponent<FollowPlayerScript>();
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
        if (collision.CompareTag("Player"))
        {
            azriWardCheck.AzriInWard = true;
        }
    }
}
