using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    [SerializeField]
    Camera cam;
    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(cam.transform);
        this.transform.Rotate(0f,180f,0f);
    }
}
