using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class AnswerPlaceBehaviour : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    GameObject[] places;

    private bool hasAnswer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        places = GameObject.FindGameObjectsWithTag("Place");
    }

    // Update is called once per frame
    void Update()
    {
        PlaceBehaviour placeA = places[0].GetComponent<PlaceBehaviour>();
        PlaceBehaviour placeB = places[1].GetComponent<PlaceBehaviour>();

        if(placeA.hasPiece && placeB.hasPiece)
        {
            IEnumerable<Color> sameColor = placeA.piecePlaced.colors.Intersect(placeB.piecePlaced.colors);

            if(sameColor.Count() > 0)
            {
                spriteRenderer.color = sameColor.ElementAt(0);

                hasAnswer = true;
            }
        }
        else if(!hasAnswer)
        {
            spriteRenderer.color = Color.gray;
        }
        else
        {
            hasAnswer = false;
        }
    }
}
