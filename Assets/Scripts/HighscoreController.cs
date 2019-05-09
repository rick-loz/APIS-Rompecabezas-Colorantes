using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighscoreController : MonoBehaviour
{
    public Text[] levels;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < levels.Length; i++)
        {
            string highScoreVariable = "Highscore" + (i+1);

            int highScore = PlayerPrefs.GetInt(highScoreVariable);

            if (highScore == int.MaxValue)
            {
                levels[i].text = "Level " + (i + 1) + ": No Highscore Yet";
            }
            else
            {
                levels[i].text = "Level " + (i + 1) + ": " + PlayerPrefs.GetInt(highScoreVariable).ToString();
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearHighscores()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            string highScoreVariable = "Highscore" + (i + 1);

            PlayerPrefs.SetInt(highScoreVariable, int.MaxValue);

            levels[i].text = "Level " + (i + 1) + ": No Highscore Yet";
        }
    }
}
