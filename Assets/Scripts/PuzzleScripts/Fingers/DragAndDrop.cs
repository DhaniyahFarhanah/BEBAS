using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] GameObject toDrag;
    [SerializeField] GameObject toDragPosition;

    [SerializeField] float dropDistance;

    [SerializeField] bool isLocked;

    Vector2 objectInitPos;

    // Start is called before the first frame update
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
            toDrag.transform.position = toDragPosition.transform.position;
        }
        else
        {
            toDrag.transform.position = objectInitPos;
        }
    }
}
