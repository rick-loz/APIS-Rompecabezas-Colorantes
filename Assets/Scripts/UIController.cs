using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int time = 0;
    public Text timer;
    public Text highscore;
    public Button nextLevel;

    //Crear un Highscore en el usuario
    void Start()
    {
        StartTimer();

        if (PlayerPrefs.HasKey("Highscore") == true)
        {
            highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            highscore.text = "No High Scores Yet";
        }
    }

    //iniciar Timer, aplicar al hacer transicion

    public void StartTimer()
    {
        time = 0;
        InvokeRepeating("IncrimentTime", 1, 1);
    }

    //Detiene timer al ganar y aplica el highscore

    public void StopTimer()
    {
        CancelInvoke();
        if (time < PlayerPrefs.GetInt("Highscore"))
        {
            SetHighscore();
        }

    }

    public void SetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", time);
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();

    }

    public void ClearHighscores()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscore.text = "No High Scores Yet";
    }

    public void ShowButton()
    {
        nextLevel.gameObject.SetActive(true);
    }

    void IncrimentTime()
    {
        time += 1;
        timer.text = "Time: " + time;
    }
}