using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// moveindirection
/// this handles the movement of the player on mobile
/// </summary>
public class moveindirection : MonoBehaviour
{

    private Touch touch;
    private Vector2 beginTouchPosition, endTouchPosition;
    public GameObject player;


    /////////////////////////////////////////////////////////////////
    //
    //  void Update()
    //
    // - Update is called once per frame
    // - this listens for touches on the screen
    //
    /////////////////////////////////////////////////////////////////

    void Update()
    {
        if (Input.touchCount > 0) //if a touch is detected
        {

            touch = Input.GetTouch(0);//set the touch to the first touch in the frame

            switch (touch.phase)
            {

                case TouchPhase.Began://if the finger is down find the beginning touch position
                    beginTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended: //if the finger is lifted find the ending position

                    endTouchPosition = touch.position;
                    if (beginTouchPosition != endTouchPosition) //if the beginning and ending touch position is different (aka a swipe)
                    {

                        if (beginTouchPosition.x < endTouchPosition.x && Mathf.Abs(beginTouchPosition.x - endTouchPosition.x) > 30) // if the end position is bigger with a margin of 30(to eliminate taps)
                            player.GetComponent<movement>().lane++; //move the lane to the right
                        else if (beginTouchPosition.x > endTouchPosition.x && Mathf.Abs(beginTouchPosition.x - endTouchPosition.x) > 30)// if the end position is smaller with a margin of 30(to eliminate taps)
                            player.GetComponent<movement>().lane = player.GetComponent<movement>().lane - 1; // move the lane to the left
                    }
                    break;
            }
        }
    }//end update
}

