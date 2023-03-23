using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayJumpscareOnDeath : MonoBehaviour
{
    public int AnimIndex;
    public float jumpscareWaitSeconds;
    public AudioClip jumpscareSound;
    [SerializeField] Animator jumpscareAnim;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] AudioSource jumpscareAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeathAnim()
    {
        jumpscareAnim.SetInteger("Type", AnimIndex);
        jumpscareAnim.SetBool("Death", true);
        jumpscareAudio.clip = jumpscareSound;
        if (!jumpscareAudio.isPlaying)
        {
            jumpscareAudio.Play();
        }

        StartCoroutine(OpenGameOver());
    }

    IEnumerator OpenGameOver()
    {
        yield return new WaitForSeconds(jumpscareWaitSeconds);
        gameOverScreen.SetActive(true);
        jumpscareAnim.SetBool("Death", false);

    }
}
