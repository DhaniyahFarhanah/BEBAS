using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MoveOnWhenVideoFinishes : MonoBehaviour
{
    [SerializeField] VideoPlayer endgamecutscene;
    [SerializeField] GameObject loader;

    scenetransition transition;
    // Start is called before the first frame update
    private void Awake()
    {
        transition = loader.GetComponent<scenetransition>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((endgamecutscene.frame) > 0 && (endgamecutscene.isPlaying == false))
        {
            StartCoroutine(BackToMain());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToMainMenu();
        }
    }

    public void ToMainMenu()
    {
        StartCoroutine(BackToMain());
    }
    IEnumerator BackToMain()
    {
        loader.SetActive(true);
        transition.transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}
