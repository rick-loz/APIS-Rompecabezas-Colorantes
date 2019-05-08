using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBehaviour : MonoBehaviour
{
    GameObject[] pieces;

    public bool hasPiece;

    public PieceBehaviour piecePlaced;

    // Start is called before the first frame update
    void Start()
    {
        hasPiece = false;

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

                        GetComponent<SpriteRenderer>().color = Color.green;
                    }
                }
            }
        }
    }

    public void resetPlace()
    {
        hasPiece = false;
        piecePlaced = null;
        GetComponent<SpriteRenderer>().color = Color.white;

    }
}
