using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMeasure : MonoBehaviour
{
    public Material red;
    public Material green;
    public Text taskStatusText;
    public string done;
    public string inProgress;

    private GameObject sliver;
    // Start is called before the first frame update

    private void Start()
    {
        sliver = GameObject.Find("Sliver");
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, sliver.transform.position) <= .01f)
        {
            SetMaterial(green);
            SetText(done);
        }
        else
        {
            SetMaterial(red);
            SetText(inProgress);
        }
    }

    void SetMaterial(Material mat)
    {
        this.GetComponent<Renderer>().material = mat;
        
    }

    void SetText(string text) {
        taskStatusText.text = text;
    }
}
