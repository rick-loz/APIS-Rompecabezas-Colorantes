using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBehaviour : MonoBehaviour
{
    GameObject[] pieces;

    public bool hasPiece;

    public bool isAnswerInOrder;

    public PieceBehaviour piecePlaced;

    public int orderInQuestion;

    // Start is called before the first frame update
    void Start()
    {
        hasPiece = false;

        isAnswerInOrder = false;

        pieces = GameObject.FindGameObjectsWithTag("Piece");
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasPiece)
        {
            for (int i = 0; i < pieces.Length && !hasPiece; i++)
            {
                if (pieces[i].transform.position.x == transform.position.x && pieces[i].transform.position.y == transform.position.y)
                {
                    if (piecePlaced == null && pieces[i].GetComponent<PieceBehaviour>().isPlaced)
                    {
                        hasPiece = true;

                        piecePlaced = pieces[i].GetComponent<PieceBehaviour>();

                        if(piecePlaced.orderInAnswer == orderInQuestion)
                        {
                            isAnswerInOrder = true;
                        }
                    }
                }
            }
        }
    }

    public void resetPlace()
    {
        hasPiece = false;
        isAnswerInOrder = false;
        piecePlaced = null;
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
