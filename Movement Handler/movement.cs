using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Movement
/// this handles the movement of the player
/// </summary>

public class movement : MonoBehaviour
{

    public Animation running;
    public Rigidbody player;
    public GameObject playerg;
    public Text Score;
    public float forward = 50;
    float acceleration = 5;
    public int lane = 2;
    public float point = 0;
    public int framecounter = 0;

    /////////////////////////////////////////////////////////////////
    //
    //  private void Awake()
    //
    // - Awake is called once in a lifetime per script
    // - This applies the SwipeDetector
    //
    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    /////////////////////////////////////////////////////////////////
    //
    // void Update()
    //
    // - called every frame
    // - this handles the movement of the player. this includes its forward and side to side movement for botth pc and mobile
    //
    /////////////////////////////////////////////////////////////////

    void Update()
    {
        //sets the score GUI component to the score integer
        Score.text = point.ToString();

        //set the rotation correctly
        this.gameObject.transform.rotation = new Quaternion(90, -90, -90, -90);

        //add to the frame counting integer
        framecounter++;

        //remove and velocity that would put them at an angle
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

        //move the player forward by a certain amount
        playerg.transform.position = new Vector3(playerg.transform.position.x, playerg.transform.position.y, playerg.transform.position.z + (forward * Time.deltaTime));

        //FOR DESKTOP DEBUGGING{
        // move left
        if (Input.GetKeyDown("a"))
        {
            lane = lane - 1;
        }
        //move right
        if (Input.GetKeyDown("d"))
        {
            lane++;
        }
        //}
        if (lane > 3)
        {
            lane = 3;
        }
        if (lane < 1)
        {
            lane = 1;
        }
        if (framecounter % 2500 * Time.deltaTime == 0)
        {
            //Debug.Log("Incremented");
            forward = forward + acceleration;
        }
        if (lane == 1)
            player.transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), new Vector3(-3.4f, player.transform.position.y, player.transform.position.z),0.1f);
        if (lane == 2)
            player.transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), new Vector3(0, player.transform.position.y, player.transform.position.z),0.1f);
        if (lane == 3)
            player.transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), new Vector3(3.4f, player.transform.position.y, player.transform.position.z), 0.1f);

    }

    /////////////////////////////////////////////////////////////////
    //
    //  private void SwipeDetector_OnSwipe(SwipeData data)
    //
    // - this returns the swipedata found by the script
    //
    /////////////////////////////////////////////////////////////////

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        string Swipeinput = (" " + data.Direction);
        if (Swipeinput == "Left")
        {
            lane = lane - 1;
        }
        if (Swipeinput == "Right")
        {
            lane++;
        }
    }

    /////////////////////////////////////////////////////////////////
    //
    //  OnCollisionEnter(Collision info)
    //
    // - This is called when unity detects a collision
    // - if the player hits a safe block, add half a point, one for entrance collision one for exit
    //
    /////////////////////////////////////////////////////////////////

    void OnCollisionEnter(Collision info)
    {

        if (info.collider.tag == "Point")
        {
            point = point + .5f;
        }
    }
}

