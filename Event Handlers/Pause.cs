using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pause
/// This is the event handler for the pause button
/// </summary>
public class Pause : MonoBehaviour
{ 
    public GameObject player;
    public bool paused = false;
    public float SavedForward;
    public GameObject PauseImage;

    /////////////////////////////////////////////////////////////////
    //
    //  void Update()
    //
    // - Update is called once per frame
    // - This tests if the pause button is selected through the associated bool and if it is, it stops the player and sets an image overlay
    //
    /////////////////////////////////////////////////////////////////

    void Update()
    {
        if (paused)
        {
            //remove all velocity 
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //show the paused overlay
            PauseImage.SetActive(true);
            //lock the acceleration
            player.GetComponent<movement>().framecounter = 0;
            //make the forward speed 0
            player.GetComponent<movement>().forward = 0;
        }

    }// end update

    /////////////////////////////////////////////////////////////////
    //
    //  public void OnClick()
    //
    // - on click is called when the button is clicked
    // - if the button is clicked it will inverse the bool of paused and will save the current speed of the player.
    //
    /////////////////////////////////////////////////////////////////

    public void OnClick()
    {
        //inverse the current value of paused
        paused = !paused;
        if (paused)
        {
            //if its paused, save the current speed of the forward speed
            SavedForward = player.GetComponent<movement>().forward;
        }
        else
        {
            //eliminate the gray and make the forward speed the saved forward speed
            PauseImage.SetActive(false);
            player.GetComponent<movement>().forward = SavedForward;
        }
    }//end click
}
