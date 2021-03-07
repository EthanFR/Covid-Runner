using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Boxesinfection
/// This script handles the obstacles and chances of infected interaction
/// </summary>

public class Boxesinfection : MonoBehaviour
{

    public Material Red;

    /////////////////////////////////////////////////////////////////
    //
    //  public float Rate()
    //
    // - this calculates the rate by getting the the buttons selected
    //
    /////////////////////////////////////////////////////////////////

    public float Rate()
    {

        GameObject buttonhandler = GameObject.Find("UI Button Handler");

        if (buttonhandler.GetComponent<InteractionButtons>().MaskOnbool)       //if wearing mask is selected
            return (1 - Mathf.Pow((1 - (buttonhandler.GetComponent<InteractionButtons>().stateinfectionrate / 100000)), buttonhandler.GetComponent<InteractionButtons>().jobinteractionrate)) * 9;
        else
            return (1 - Mathf.Pow((1 - (buttonhandler.GetComponent<InteractionButtons>().stateinfectionrate / 100000)), buttonhandler.GetComponent<InteractionButtons>().jobinteractionrate)) * 100;

    }

    /////////////////////////////////////////////////////////////////
    //
    //  void Start()
    //
    // - called at the start
    // - This is also called when each block is generated
    // - Once the block is generated this will set it up as a normal point then run the chances of infection. if it is unbclucky it will select one of the blocks to be an obstacle
    //
    /////////////////////////////////////////////////////////////////	

    void Start()
    {
        GameObject buttonhandler = GameObject.Find("UI Button Handler");
        //Debug.Log(buttonhandler.GetComponent<InteractionButtons>().stateinfectionrate);
        //Debug.Log(buttonhandler.GetComponent<InteractionButtons>().jobinteractionrate);
        //this creates a list of the children
        Transform[] children = this.gameObject.GetComponentsInChildren<Transform>();

        //run the percentage
        int infected = UnityEngine.Random.Range(0, 100);

        //add the factors to the children{
        children[1].gameObject.AddComponent<BoxCollider>();
        children[1].gameObject.GetComponent<BoxCollider>().enabled = true;
        children[1].gameObject.GetComponent<BoxCollider>().isTrigger = false;
        children[1].gameObject.AddComponent<Rigidbody>();
        children[1].gameObject.GetComponent<Rigidbody>().useGravity = false;
        children[1].gameObject.GetComponent<Rigidbody>().isKinematic = false;
        children[1].tag = "Point";

        children[2].gameObject.AddComponent<BoxCollider>();
        children[2].gameObject.GetComponent<BoxCollider>().enabled = true;
        children[2].gameObject.GetComponent<BoxCollider>().isTrigger = false;
        children[2].gameObject.AddComponent<Rigidbody>();
        children[2].gameObject.GetComponent<Rigidbody>().useGravity = false;
        children[2].gameObject.GetComponent<Rigidbody>().isKinematic = false;
        children[2].tag = "Point";

        children[3].gameObject.AddComponent<BoxCollider>();
        children[3].gameObject.GetComponent<BoxCollider>().enabled = true;
        children[3].gameObject.GetComponent<BoxCollider>().isTrigger = false;
        children[3].gameObject.AddComponent<Rigidbody>();
        children[3].gameObject.GetComponent<Rigidbody>().useGravity = false;
        children[3].gameObject.GetComponent<Rigidbody>().isKinematic = false;
        children[3].tag = "Point";
        //}


        if (infected <= Rate()) //if the chance comes true
        {
            int r = UnityEngine.Random.Range(1, 4); // choose one of the 3 blocks
            try
            {
                //make the block an obstacle
                children[r].GetComponent<MeshRenderer>().material = Red;
                children[r].GetComponent<BoxCollider>().enabled = true;
                children[r].GetComponent<BoxCollider>().isTrigger = false;
                children[r].transform.position = new Vector3(children[r].transform.position.x, children[r].transform.position.y, children[r].transform.position.z);
                children[r].tag = "Obstacle";
                r = 0;
            }
            catch (Exception e)
            {

            }
        }

    }

    /////////////////////////////////////////////////////////////////
    //
    //  void Update()
    //
    // - Update is called once per frame
    // - this controls the day count output
    //
    /////////////////////////////////////////////////////////////////

    void Update()
    {
        try
        {
            //set the percent GUI to the calculated percent
            GameObject.Find("Percent").GetComponent<Text>().text = Rate().ToString("n2") + "%";
        }
        catch (Exception e)
        {

        }

    }

}
