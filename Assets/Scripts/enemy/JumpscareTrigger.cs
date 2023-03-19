using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    [SerializeField] GameObject JumpscareHud;
    [SerializeField] GameObject Jumpscare;
    Animator JumpscareAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        JumpscareAnimator = Jumpscare.GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            JumpscareHud.SetActive(true);
            StartCoroutine(PlayJumpscare());
        }
    }

    IEnumerator PlayJumpscare()
    {
        yield return new WaitForSeconds(0.5f);
        Jumpscare.SetActive(true);
        JumpscareAnimator.SetInteger("Type", 3);
        JumpscareAnimator.SetBool("Death", false);
        yield return new WaitForSeconds(1f);
        Jumpscare.SetActive(false);
        JumpscareHud.SetActive(false);
    }
}
