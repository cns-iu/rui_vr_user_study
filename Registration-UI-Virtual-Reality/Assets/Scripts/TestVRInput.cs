using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TestVRInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.GetStateDown("Grab", SteamVR_Input_Sources.Any))
        {
            Debug.Log("gotcha");
        }
    }
}
