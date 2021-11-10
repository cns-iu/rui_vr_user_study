using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SetUIFont : MonoBehaviour
{
    [SerializeField]
    Font f;

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("");
        Text[] textComponents = Component.FindObjectsOfType<Text>();
        //Debug.Log(textComponents.Length);
        foreach (var item in textComponents)
        {
            item.font = f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
