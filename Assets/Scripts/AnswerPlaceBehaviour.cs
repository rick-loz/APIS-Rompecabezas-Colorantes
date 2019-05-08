﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class AnswerPlaceBehaviour : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    GameObject[] places;

    private bool hasAnswer;

    private Color initialColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        places = GameObject.FindGameObjectsWithTag("Place");

        initialColor = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {

        bool allHavePiece = true;

        for(int i = 0; i < places.Length && allHavePiece; i++)
        {
            if( !places[i].GetComponent<PlaceBehaviour>().hasPiece )
            {
                allHavePiece = false;
            }
        }

        if( allHavePiece )
        {

            List<Color> sharedColors = places[0].GetComponent<PlaceBehaviour>().piecePlaced.colors;

            bool allHaveCommon = true;

            for (int i = 1; i < places.Length && allHaveCommon; i++)
            {
                PlaceBehaviour otherPlace = places[i].GetComponent<PlaceBehaviour>();

                IEnumerable<Color> equalColors = sharedColors.Intersect(otherPlace.piecePlaced.colors);

                if (equalColors.Count() > 0)
                {
                    sharedColors = new List<Color>(equalColors.ToList());
                }
                else
                {
                    allHaveCommon = false;
                }

            }

            if (allHaveCommon)
            {
                spriteRenderer.color = sharedColors.ElementAt(0);

                hasAnswer = true;
            }
            else if(!hasAnswer)
            {
                spriteRenderer.color = initialColor;
            }
            else
            {
                hasAnswer = false;
            }
        }
        else if (!hasAnswer)
        {
            spriteRenderer.color = initialColor;
        }
        else
        {
            hasAnswer = false;
        }


        /* 

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

     */
    }
}
