using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public float speed;
    // Update is called once per frame

    //private void Start()
    //{
    //    Time.timeScale = 1f;
    //}

    void Update()
    {
        Debug.Log(Time.timeScale);
        this.transform.Rotate(0f, 1 * speed * Time.deltaTime, 0f);
    }
}
