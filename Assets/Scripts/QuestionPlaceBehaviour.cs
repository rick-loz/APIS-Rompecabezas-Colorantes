using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPlaceBehaviour : MonoBehaviour
{
    private Color questionColor;

    private GameObject answerPlace;

    // Start is called before the first frame update
    void Start()
    {
        questionColor = GetComponent<SpriteRenderer>().color;

        answerPlace = GameObject.FindGameObjectWithTag("AnswerPlace");
    }

    // Update is called once per frame
    void Update()
    {
        if(answerPlace.GetComponent<AnswerPlaceBehaviour>().hasAnswer)
        {
           // GetComponent<SpriteRenderer>().color = Color.green;

            if (answerPlace.GetComponent<SpriteRenderer>().color == questionColor)
            {

                UIController gameController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();

                gameController.StopTimer();

                gameController.ShowButton();
            }
        }
    }
}
