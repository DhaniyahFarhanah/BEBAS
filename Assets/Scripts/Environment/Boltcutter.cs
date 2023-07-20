using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boltcutter : MonoBehaviour
{

    [SerializeField] GameObject hasBoltcutter;
    [SerializeField] GameObject noBoltcutter;

    DialogueScript dialogueIndex;
    // Start is called before the first frame update

    private void Awake()
    {
        dialogueIndex = GetComponent<DialogueScript>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueIndex.index > 1)
        {
            hasBoltcutter.SetActive(true);
            noBoltcutter.SetActive(false);
        }

        
    }
}
