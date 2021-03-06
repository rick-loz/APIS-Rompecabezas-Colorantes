﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviour : MonoBehaviour
{

    private Vector2 initialPos;

    private float deltaX, deltaY;

    private int placeIndex;

    public bool isPlaced;

    public List<Color> colors;

    public int orderInAnswer;

    GameObject[] places;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        isPlaced = false;
        places = GameObject.FindGameObjectsWithTag("Place");
        placeIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            Vector2 touchPosWorld2D = new Vector2(touchPos.x, touchPos.y);


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics2D.OverlapPoint(touchPosWorld2D) == GetComponent<Collider2D>())
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:

                    if (Physics2D.OverlapPoint(touchPosWorld2D) == GetComponent<Collider2D>())
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);

                        isPlaced = false;

                        if (placeIndex >= 0)
                        {
                            places[placeIndex].GetComponent<PlaceBehaviour>().resetPlace();

                            placeIndex = -1;
                        }
                    }
                    break;

                case TouchPhase.Ended:

                    for(int i = 0; i < places.Length && !isPlaced; i++)
                    {
                        if (Mathf.Abs(transform.position.x - places[i].transform.position.x) <= 0.5f &&
                            Mathf.Abs(transform.position.y - places[i].transform.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(places[i].transform.position.x, places[i].transform.position.y);

                            isPlaced = true;

                            placeIndex = i;
                        }
                    }

                    if(!isPlaced)
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                    }
                    break;
            }
        }
    }
}
