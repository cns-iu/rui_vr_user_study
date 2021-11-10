using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetAndSliverSizes : MonoBehaviour
{
    public float rescaleX;
    public float rescaleY;
    public float rescaleZ;

    public TaskManager tm;
    public float kidneyHeight;

    // Start is called before the first frame update
    void Start()
    {
        tm.currentSliver.transform.localScale = new Vector3(kidneyHeight * rescaleX, kidneyHeight * rescaleX, kidneyHeight * rescaleX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
