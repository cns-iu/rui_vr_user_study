using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform sliverStartPos;

    //private void OnEnable()
    //{
    //    TaskManager.TaskUpdateEvent +=
    //}

    //private void OnDisable()
    //{
    //    TaskManager.TaskUpdateEvent -=
    //}

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(sliverStartPos);
        transform.Rotate(0f,90f,0f);
    }
}
