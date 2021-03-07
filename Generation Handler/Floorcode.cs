using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorcode : MonoBehaviour
{

    /////////////////////////////////////////////////////////////////
    //
    //  void Update()
    //
    // - this is called every frame
    // - this just reassures the floor wont be considered an obstacle
    //
    /////////////////////////////////////////////////////////////////

    void Update()
    {
        // the floor should never be marked as an obsticle
        this.gameObject.tag = "Untagged";
    }
}
