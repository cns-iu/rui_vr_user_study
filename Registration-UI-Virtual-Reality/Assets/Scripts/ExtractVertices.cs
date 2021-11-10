using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractVertices : MonoBehaviour
{
    public Transform origin;
    public Mesh mesh;
    public Vector3[] rawVertices;
    public Vector3[] exportVertices;
    
    public Vector3[] GetVertices()
    {
        //mesh = GetComponent<MeshFilter>().mesh;
        //rawVertices = mesh.vertices;
        for (int i = 0; i < rawVertices.Length; i++)
        {
            Vector3 worldPt = transform.TransformPoint(rawVertices[i]);
            Vector3 exportPoint = (worldPt - origin.position) * 2f;
            //Debug.Log(exportPoint);
            //exportVertices[i] = exportPoint;
            //GameObject currentSphere = Instantiate(pre_sphere, worldPt, pre_sphere.transform.rotation);
            //currentSphere.GetComponentInChildren<Text>().text = i.ToString();
        }

        return exportVertices;

       
        
        //Debug.Log(vertices.ToString());
    }

    private void Start()
    {
        //Debug.Log(GetVertices());
    }

}
