using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mngr : MonoBehaviour
{
    public void Switch()
    {
        SceneManager.LoadScene("Gameplay_Alpha");
    }
}
