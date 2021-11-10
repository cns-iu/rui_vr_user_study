using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustZoom : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Camera>().orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }

    public void ResetCamera() {
        //Debug.Log("called");
        this.GetComponent<Camera>().orthographicSize = 5;
    }
}
