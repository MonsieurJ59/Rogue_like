using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string scene;

    public void Quit()
    {
        Application.Quit();
    }

    public void SceneLoader()
    {
        SceneManager.LoadScene(scene);
    }
}