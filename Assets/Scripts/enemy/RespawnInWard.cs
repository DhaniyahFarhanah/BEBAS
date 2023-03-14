using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnInWard : MonoBehaviour
{

    FollowPlayerScript isHere;
    // Start is called before the first frame update

    private void Awake()
    {
        isHere = gameObject.GetComponent<FollowPlayerScript>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHere.AzriInWard)
        {
            //idk if this is the coords to the ward
            gameObject.transform.position = new Vector2(287, 19.29f);
        }
    }
}
