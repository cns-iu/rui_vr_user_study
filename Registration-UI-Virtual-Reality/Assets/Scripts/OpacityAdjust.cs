using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityAdjust : MonoBehaviour
{
    public Material mat_kidney;
    // Start is called before the first frame update
    void Start()
    {
        
        this.GetComponent<Slider>().onValueChanged.AddListener(
            delegate
            {
                SetOpacity();
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetOpacity() {
        Debug.Log("new opacity: " + this.GetComponent<Slider>().value);
        Color color = mat_kidney.color;
        mat_kidney.color = new Color(
            color.r,
            color.g,
            color.b,
            this.GetComponent<Slider>().value
            );
    }
}
