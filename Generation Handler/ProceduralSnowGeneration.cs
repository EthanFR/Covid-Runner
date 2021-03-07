using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ProceduralSnowGeneration
/// This generates paths in front and deletes paths behind the player
/// </summary>

public class ProceduralSnowGeneration : MonoBehaviour
{

    public GameObject Obsticle;
    public Material Material1;
    private Transform player;
    public float spawnZ = -30f;
    private float safeZone = 180.0f;
    public int pathsonscreen = 5;
    private int lastPrefabIndex = 0;
    public List<GameObject> activePaths;

    /////////////////////////////////////////////////////////////////
    //
    //  void Start()
    //
    // - Start is called before the first frame update
    // - This summons the first couble of paths for the player to play on	
    //
    /////////////////////////////////////////////////////////////////

    void Start()
    {

        activePaths = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //When game starts generate 5 paths
        for (int i = 0; i < pathsonscreen; i++)
        {
            SpawnPath();
        }
    }

    /////////////////////////////////////////////////////////////////
    //
    //  void Update()
    //
    // - Update is called once per frame
    // - This listens to the sensors to see if the player is far enough away to cycle paths
    //
    /////////////////////////////////////////////////////////////////

    void Update()
    { // if the player is far enough past the last path, add a new one then delete the last one
        if (player.position.z - 180 > (spawnZ - pathsonscreen * 100))
        {
            SpawnPath();
            DeletePath();
        }
    }

    /////////////////////////////////////////////////////////////////
    //
    //  public void SpawnPath() 
    //
    // - SpawnPath() spawns a path a specified distance in front
    // - this generates the path, sets its location and then adds all the necessary components the boxes need
    //
    /////////////////////////////////////////////////////////////////

    public void SpawnPath()
    {
        //Instantiate copies a prefab and sets an empty game object to a clone
        //Create a prefab of path
        GameObject path;
        path = Instantiate(Obsticle) as GameObject;
        //set its location to the parent 
        path.transform.SetParent(transform);
        //if the Game Object is the ground, make it not trigger collisions
        if (path.gameObject.name.Contains("Ground"))
        {
            path.GetComponent<BoxCollider>().isTrigger = false;
        }


        //go forward to the new path slot
        path.transform.position = Vector3.forward * spawnZ;

        //search through the prefab and if it is a block, add the box infection handler
        //box infection determines if a block is an obstacle
        try
        {
            foreach (Transform child in path.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject.name.Contains("Day"))
                {
                    child.gameObject.AddComponent<Boxesinfection>();
                    child.gameObject.GetComponent<Boxesinfection>().Red = Material1;
                }
            }
        }
        catch (Exception e)
        {

        }


        //Add to the path slot
        spawnZ += 100;
        //add it to the active paths
        activePaths.Add(path);
    }

    /////////////////////////////////////////////////////////////////
    //
    //  public void DeletePath()
    //
    // - This removes the oldest path or the last path
    //
    /////////////////////////////////////////////////////////////////

    public void DeletePath()
    {
        //delete the oldest path aka the last path
        Destroy(activePaths[0]);
        activePaths.RemoveAt(0);
    }
}
