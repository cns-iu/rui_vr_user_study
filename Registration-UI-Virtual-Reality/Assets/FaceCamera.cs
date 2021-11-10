using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public GameObject arrow;
    public Camera cam;
    public Transform sliverStartPos;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = cam.transform.position;
        transform.LookAt(camPos);
        transform.Rotate(0f, 180f, 0f, Space.Self);
        //float startY = arrow.transform.position.y;
        //arrow.transform.position = new Vector3(sliverStartPos.position.x, startY, sliverStartPos.position.z);
        //arrow.gameObject.transform.LookAt(camPos);
        //float yAngle = arrow.gameObject.transform.eulerAngles.y;
        //arrow.gameObject.transform.eulerAngles = new Vector3(0f, yAngle, 90f);
    }
}
