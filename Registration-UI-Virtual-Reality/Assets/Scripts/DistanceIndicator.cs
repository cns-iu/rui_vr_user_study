using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceIndicator : MonoBehaviour
{
    public GameObject target;
    public GameObject sliver;
    private float distance;
    public GameObject[] DistanceTexts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <DistanceTexts.Length; i++)
        {
            DistanceTexts[i].GetComponent<Text>().text = Vector3.Distance(target.transform.position, sliver.transform.position).ToString();
        }
        
           
     
    }
}
