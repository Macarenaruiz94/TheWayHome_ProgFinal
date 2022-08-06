using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boton : MonoBehaviour
{
    public string scene;

    //load scene on click
    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

    //exit game on click
    public void QuitGame()
    {
        Application.Quit();
    }
}
