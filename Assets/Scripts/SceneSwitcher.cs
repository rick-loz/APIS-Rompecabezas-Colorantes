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

    public void GoToReadings()
    {
        SceneManager.LoadScene("ReadingsListScene");
    }

    public void GoToSpecificReading()
    {
        SceneManager.LoadScene("ReadingSubject");
    }

    public void GoToHighscores()
    {
        SceneManager.LoadScene("HighscoresScene");
    }
}
