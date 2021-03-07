using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Reset
/// This is the Eventhandler for the reset button
/// </summary>

public class Reset : MonoBehaviour
{
    public MusicHandler music;
    public movement move;
    public ProceduralSnowGeneration blocks;
    public Rigidbody playerr;
    public GameObject player;
    public GameObject filemanager;
    public Vector3 Naturalposition;
    public Quaternion Naturalrotation;
    public Vector3 NaturallocalScale;
    public GameObject DeathImage;

    /////////////////////////////////////////////////////////////////
    //
    //  public void OnClick()
    //
    // - This is called when the reset button is clicked
    // - When the reset button is clicked, it makes the player alive again, repositions it, deletes the paths then creates more. It finally re-enables move so the player can keep on playing
    //
    /////////////////////////////////////////////////////////////////

    public void OnClick()
    {
        music.song1selected = true;

        player = GameObject.Find("Player");
        player.GetComponent<Death>().dead = false; // find the player object and set "dead" to false

        DeathImage.SetActive(false);//remove the overlay from death

        player.transform.rotation = new Quaternion(-90, 90, 90, 90); // set its rotation to normal

        player.transform.position = new Vector3(.3f, 7.28f, 9.9f); // set the location to the beginning

        blocks.spawnZ = -30f; // reset the location where the path spawns back to normal

        blocks.pathsonscreen = 5; // request 5 paths on screen 

        for (int i = 0; i < blocks.pathsonscreen; i++) //spawn the new paths
        {
            blocks.SpawnPath();
        }

        for (int i = 0; i < blocks.activePaths.Count; i++) // delete the old paths
        {
            blocks.DeletePath();
        }

        playerr.useGravity = true; // use gravity again
        playerr.velocity = new Vector3(0, 0, 0); //make sure it has no velocity just to be safe

        move.enabled = true; // re-enable the script that allows the player to move
        move.lane = 2; // set the players location to the middle lane
        move.forward = 50; // reset the move forward function from the script

        player.GetComponent<movement>().point = 0; //reset the point count

        Destroy(player.GetComponent<Death>().Ragdolls[0]); //destroy the old ragdoll
        player.GetComponent<Death>().Ragdolls.RemoveAt(0);// remove it from the list
    }

}
