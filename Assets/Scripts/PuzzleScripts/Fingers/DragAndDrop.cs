using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] GameObject toDrag;
    [SerializeField] GameObject toDragPosition;
    [SerializeField] GameObject CheckFingerCollect;

    [SerializeField] AudioSource attachFingerSound;

    [SerializeField] float dropDistance;

    [SerializeField] int index;
    [SerializeField] bool isLocked;

    CheckFingerCollect fingerUpdate;

    Vector2 objectInitPos;

    // Start is called before the first frame update

    private void Awake()
    {
        fingerUpdate = CheckFingerCollect.GetComponent<CheckFingerCollect>();
    }
    void Start()
    {
        objectInitPos = toDrag.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            toDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float dist = Vector3.Distance(toDrag.transform.position, toDragPosition.transform.position);

        if(dist < dropDistance)
        {
            isLocked = true;
            fingerUpdate.isAttached[index] = true;
            attachFingerSound.Play();

            toDrag.transform.position = toDragPosition.transform.position;
        }
        else
        {
            toDrag.transform.position = objectInitPos;
        }
    }
}
