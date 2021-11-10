using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRotationFromSlider : MonoBehaviour
{
    public GameObject slider;

    private float value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = slider.GetComponent<Slider>().value;
        this.transform.eulerAngles = new Vector3(0f,value,0f);
    }
}
