using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GoToLevel(int index)
    {
        SceneManager.LoadScene("Level" + index + "Scene");
    }
}
