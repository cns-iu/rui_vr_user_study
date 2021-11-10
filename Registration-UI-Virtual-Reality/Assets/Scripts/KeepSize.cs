using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSize : MonoBehaviour
{
    private Vector3 initialSize;

    private void Awake()
    {
        initialSize = this.transform.localScale;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = initialSize;
    }
}
