using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PressEscToGoToGameplay : MonoBehaviour
{
    [SerializeField] GameObject loader;

    scenetransition transition;
    // Start is called before the first frame update
    private void Awake()
    {
        transition = loader.GetComponent<scenetransition>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
        SceneManager.LoadScene("Gameplay");
    }
}
