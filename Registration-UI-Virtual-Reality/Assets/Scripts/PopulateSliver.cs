using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopulateSliver : MonoBehaviour
{
    public GameObject pre_sphere;
    public GameObject sliverPos;
    public Material sliverMat;
    public bool drawSliverGizmo = true;

    private Vector3 center;

    [SerializeField]
    private List<Collider> colliders = new List<Collider>();

    private void Awake()
    {
        center = this.transform.position;
        //Debug.Log("hello world");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bubble")
        {
            colliders.Add(other);
        }
        
    }

    private void Start()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            GameObject sphereCopy = Instantiate(pre_sphere, colliders[i].transform.position, colliders[i].transform.rotation);
            sphereCopy.transform.parent = this.transform;
            sphereCopy.GetComponent<Renderer>().material = colliders[i].GetComponent<Renderer>().material;
            //sphereCopy.layer = 11;
        }
        this.transform.position = sliverPos.transform.position;
        if (drawSliverGizmo)
        {
            DrawSliverGizmo();
        }
       
    }

    void DrawSliverGizmo() {
        GameObject sliverGizmo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        sliverGizmo.GetComponent<Renderer>().material = sliverMat;
        sliverGizmo.transform.localScale = this.transform.localScale;
        sliverGizmo.GetComponent<BoxCollider>().enabled = false;
        sliverGizmo.transform.position = GameObject.Find("KidneyCube").GetComponent<SpawnSliver>().sliverSpawnPos;
        sliverGizmo.transform.rotation = Quaternion.Euler(GameObject.Find("KidneyCube").GetComponent<SpawnSliver>().sliverSpawnRot);
        sliverGizmo.transform.parent = GameObject.Find("KidneyCube").transform;
    }



}
