using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardLightsOn : MonoBehaviour
{
    FuseBoxPuzzleScript fuseBoxPuzzle;

    [SerializeField] GameObject fusePuzzle;
    [SerializeField] GameObject HellNO;

    [SerializeField] Animator anim;

    // Start is called before the first frame update

    void Awake()
    {
        fuseBoxPuzzle = fusePuzzle.GetComponent<FuseBoxPuzzleScript>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLightsOn();
    }

    void CheckLightsOn()
    {
        if(fuseBoxPuzzle.lightsOn == true)
        {
            StartCoroutine(Wait());
        }
        else if(fuseBoxPuzzle.lightsOn == false)
        {
            anim.SetBool("Light", false);
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("Light",true);
        HellNO.SetActive(false);
    }
}
