using System.Collections;
using TMPro;
using UnityEngine;

public class displayControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshPro>().text = combinationpuzzle.playerCode;
    }
}
