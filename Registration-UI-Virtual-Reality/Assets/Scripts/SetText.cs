using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.Round(this.GetComponent<Slider>().value).ToString();
    }
}
