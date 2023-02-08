using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dogecheck;

    public GameObject[] pieces;

    public int totalPieces = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalPieces = dogecheck.transform.childCount;

        pieces = new GameObject[totalPieces];

        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i] = dogecheck.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
