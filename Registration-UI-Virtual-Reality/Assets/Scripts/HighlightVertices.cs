using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightVertices : MonoBehaviour
{
    Mesh mesh;
    public Vector3[] vertices;

    public GameObject pre_sphere;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    public void PrintVertices() {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPt = transform.TransformPoint(vertices[i]);
            Debug.Log(worldPt);
            //GameObject currentSphere = Instantiate(pre_sphere, worldPt, pre_sphere.transform.rotation);
            //currentSphere.GetComponentInChildren<Text>().text = i.ToString();
        }
        //Debug.Log(vertices.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateVertices();
    }

    void UpdateVertices() {
        Debug.Log(vertices[0]);
    }
}
