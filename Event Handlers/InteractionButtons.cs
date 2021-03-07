using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Interaction button
/// this handles a majority of the GUIinteraction event handlers
/// </summary>

public class InteractionButtons : MonoBehaviour
{

    public MusicHandler music;

    public float stateinfectionrate;
    public float jobinteractionrate;

    public Button NorthDakota;
    public Button NewMexico;
    public Button Vermont;
    public Button Teacher;
    public Button Cashier;
    public Button StayAtHome;
    public Button Mute;

    public Text StateTitle;
    public Text JobTitle;

    public Button MaskOn;

    public GameObject Info;
    public GameObject Help;

    public bool MaskOnbool = true;
    public bool Mutebool = false;

    /////////////////////////////////////////////////////////////////
    //
    //   public void Update()
    //
    //	- Update is called once per frame
    //	- This simply handles the color of the mask on button based on if the bool associated with it is on or off
    //
    ///////////////////////////////////////////////////////////////// 
    void Start()
    {
        stateinfectionrate = 731;
        jobinteractionrate = 4;
    }
    void Update()
    {
        if (MaskOnbool)//if wearing mask
            MaskOn.GetComponent<Image>().color = Color.green; //set the button color to green
        else
            MaskOn.GetComponent<Image>().color = Color.white; //set the button color to white
        if (Mutebool)//if muted
            Mute.GetComponent<Image>().color = Color.red; //set the button color to green
        else
            Mute.GetComponent<Image>().color = Color.green; //set the button color to white
        music.mute = Mutebool; 
    }
    

    /////////////////////////////////////////////////////////////////
    //
    //   public void OnClick(string buttonname)
    //
    //	- Method detects the click and passes through the name of the object that was clicked
    //	- Handles the buttons for North Dakota, New Mexico, Vermont, Stay At Home, Teacher, Cashier, masks on, info tab, and close info tab.
    //	- Many of these buttons will set variables that determine the speed of the approaching blocks
    //
    ///////////////////////////////////////////////////////////////// 

    public void OnClick(string buttonname)
    {
        if (buttonname == "North Dakota") //if the thing click is named North Dakota
        {
            StateTitle.text = "State Containment Measures: Low";
            NorthDakota.GetComponent<Image>().color = Color.green;
            NewMexico.GetComponent<Image>().color = Color.white;
            Vermont.GetComponent<Image>().color = Color.white;
            //stateinfectionrate = 12463;
            stateinfectionrate = 4986;
        }
        if (buttonname == "Michigan")  //if the thing click is named Michigan
        {
            StateTitle.text = "State Containment Measures: Medium";
            NorthDakota.GetComponent<Image>().color = Color.white;
            NewMexico.GetComponent<Image>().color = Color.green;
            Vermont.GetComponent<Image>().color = Color.white;
            stateinfectionrate = 2448;
        }
        if (buttonname == "Hawaii")  //if the thing click is named Hawaii
        {
            StateTitle.text = "State Containment Measures: High";
            NorthDakota.GetComponent<Image>().color = Color.white;
            NewMexico.GetComponent<Image>().color = Color.white;
            Vermont.GetComponent<Image>().color = Color.green;
            //stateinfectionrate = 1827;
            stateinfectionrate = 731;
        }
        if (buttonname == "StayAtHome")  //if the thing click is named Stay At Home
        {
            JobTitle.text = "Risk of Exposure: Low";
            StayAtHome.GetComponent<Image>().color = Color.green;
            Cashier.GetComponent<Image>().color = Color.white;
            Teacher.GetComponent<Image>().color = Color.white;
            jobinteractionrate = 4;
        }
        if (buttonname == "Teacher ")  //if the thing click is named Teacher
        {
            JobTitle.text = "Risk of Exposure: Medium";
            StayAtHome.GetComponent<Image>().color = Color.white;
            Teacher.GetComponent<Image>().color = Color.green;
            Cashier.GetComponent<Image>().color = Color.white;
            jobinteractionrate = 121;
        }
        if (buttonname == "Cashier")  //if the thing click is named Cashier
        {
            JobTitle.text = "Risk of Exposure: High";
            StayAtHome.GetComponent<Image>().color = Color.white;
            Teacher.GetComponent<Image>().color = Color.white;
            Cashier.GetComponent<Image>().color = Color.green;
            jobinteractionrate = 224;
        }
        if (buttonname == "Mask")  //if the thing click is named Mask
        {
            MaskOnbool = !MaskOnbool;
            //inverse the maskbool

        }
        if (buttonname == "mute")  //if the thing click is named Mask
        {
            Mutebool = !Mutebool;
            //inverse the maskbool

        }
        if (buttonname == "info") //if the thing click is named info
        {
            Info.SetActive(true);
            //show the info tab

        }
        if (buttonname == "closeinfo") //if the thing click is named close
        {
            Info.SetActive(false);
            //close the info tab

        }
        if (buttonname == "help") //if the thing click is named info
        {
            Help.SetActive(true);
            //show the info tab

        }
        if (buttonname == "closehelp") //if the thing click is named info
        {
            Help.SetActive(false);
            //show the info tab

        }


    }
}
