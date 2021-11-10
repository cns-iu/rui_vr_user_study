using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTickMarks : MonoBehaviour
{
    public Text[] marks;
    public string middle = "";
   
    // Update is called once per frame
    void Update()
    {
        marks[0].text = this.GetComponent<Slider>().minValue.ToString();
        marks[2].text = this.GetComponent<Slider>().maxValue.ToString();

        marks[1].text = middle;
    }
}
