using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //Script done by Dhaniyah Farhanah Binte Yusoff

    [SerializeField] GameObject toDrag;
    [SerializeField] GameObject toDragPosition;
    [SerializeField] GameObject CheckFingerCollect;

    [SerializeField] AudioSource attachFingerSound;

    [SerializeField] float dropDistance;

    [SerializeField] int index;
    [SerializeField] bool isLocked;

    CheckFingerCollect fingerUpdate;

    Vector2 objectInitPos;
    Quaternion initRotation;

    // Start is called before the first frame update

    private void Awake()
    {
        fingerUpdate = CheckFingerCollect.GetComponent<CheckFingerCollect>();
    }
    void Start()
    {
        objectInitPos = toDrag.transform.position;
        initRotation = toDrag.transform.rotation;
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
            toDrag.transform.rotation = toDragPosition.transform.rotation;
        }
        else
        {
            toDrag.transform.position = objectInitPos;
            toDrag.transform.rotation = initRotation;
        }
    }
}
