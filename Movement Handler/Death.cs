using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Death
/// This handles what happens when the player collides with an obstacle
/// </summary>

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public movement move;
    public MusicHandler music;
    public Rigidbody playerr;
    public GameObject RagDoll;
    public GameObject camera;
    public GameObject player;
    public Vector3 position;
    public GameObject DeathImage;
    public List<GameObject> Ragdolls;
    public bool dead = false;

    /////////////////////////////////////////////////////////////////
    //
    //  void Start()
    //
    // - called at beginning of program
    // - this goes through each bone in the rag doll and sets it into a stasis state where it cant move and has no gravity
    //
    /////////////////////////////////////////////////////////////////

    void Start()
    {
        foreach (Rigidbody child in RagDoll.GetComponentsInChildren<Rigidbody>())
        {
            child.useGravity = false;
            child.angularVelocity = new Vector3(0, 0, 0);
            child.velocity = new Vector3(0, 0, 0);

        }
    }

    /////////////////////////////////////////////////////////////////
    //
    //  void Update()
    //
    // - this is called every frame
    // - all it does is it lets the camera position in relation to the player and makes sure the ragdoll isnt moving
    //
    /////////////////////////////////////////////////////////////////

    void Update()
    {
        if (!dead)//aka if alive
            camera.transform.position = player.transform.position + position;

        //this keeps the rag doll prefab in a stasis state
        foreach (Rigidbody child in RagDoll.GetComponentsInChildren<Rigidbody>())
        {
            child.velocity = new Vector3(0, 0, 0);
            child.angularVelocity = new Vector3(0, 0, 0);
        }
    }

    /////////////////////////////////////////////////////////////////
    //
    //  void OnCollisionEnter(Collision info)
    //
    // - This is called when there is a collision
    // - if there is a collision detected, its an obstacle, and the player is alive disable the movment script create a clone of the ragdoll add a force to the ragdoll and simoultaniously teleport the ragdoll there and the player away
    //    
    /////////////////////////////////////////////////////////////////    

    void OnCollisionEnter(Collision info)
    {
        if (info.collider.tag != "Obstacle")
        {
            music.daypass();
        }
            // if the player hits an object with the obstacle tag 
            if (info.collider.tag == "Obstacle")
        {

            if (!dead)//aka if alive
            {
                //disable the movement script 
                move.enabled = false;

                //play death sound
                music.death();

                //set the dead bool to true
                dead = true;

                //set red overlay
                DeathImage.SetActive(true);

                //Ragdoll Managment{
                int r = Random.Range(100, 1000);

                //clone the ragdoll and add to it a list
                GameObject RagdollInst;
                RagdollInst = Instantiate(RagDoll) as GameObject;
                Ragdolls.Add(RagdollInst);

                //for each bone in the clone
                foreach (Rigidbody child in RagdollInst.GetComponentsInChildren<Rigidbody>())
                {
                    child.useGravity = true;
                    child.AddForce(0, 1000, r); // adds a random forward force between 100 and 1000
                }

                // set clone to position of the now dead player
                RagdollInst.transform.position = player.transform.position + new Vector3(0, -.8f, -1);
                //}

                //teleport the player far away and remove gravity
                player.transform.position = new Vector3(0, -100, 0);
                playerr.useGravity = false;
            }
        }
    }
}

