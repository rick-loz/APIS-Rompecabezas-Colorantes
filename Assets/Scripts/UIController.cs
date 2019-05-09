using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int time = 0;

    private string highScoreVariable;

    public Text timer;
    public Text highscore;
    public Button nextLevel;

    public int level = 0;

    //Crear un Highscore en el usuario
    void Start()
    {
        highScoreVariable = "Highscore" + level;

        StartTimer();

        if (PlayerPrefs.HasKey(highScoreVariable) == true)
        {
            highscore.text = "Highscore: " + PlayerPrefs.GetInt(highScoreVariable).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(highScoreVariable, int.MaxValue);
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

        int highScore = PlayerPrefs.GetInt(highScoreVariable);
        if (time < highScore)
        {
            SetHighscore();
        }

    }

    public void SetHighscore()
    {
        PlayerPrefs.SetInt(highScoreVariable, time);
        highscore.text = "Highscore: " + PlayerPrefs.GetInt(highScoreVariable).ToString();

    }

    public void ClearHighscores()
    {
        PlayerPrefs.DeleteKey(highScoreVariable);
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