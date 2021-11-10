using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubbles : MonoBehaviour
{
    public int numSpheres;
    public GameObject pre_sphere;
    public GameObject kidney;
    public Material[] materials; 

    private Vector3 center;
    private Vector3 scale;

    private Vector3 sphereSize;

    private void Awake()
    {
        center = kidney.transform.position;
        scale = kidney.transform.localScale;
        sphereSize = pre_sphere.transform.localScale;

        for (int i = 0; i < numSpheres; i++)
        {
            float r;
            r = sphereSize.x/2;
            float x, y, z;
            x = center.x + Random.Range(-scale.x/2+r, scale.x/2 - r);
            y = center.y + Random.Range(-scale.y / 2 + r, scale.y / 2 - r);
            z = center.z + Random.Range(-scale.z / 2 + r, scale.z / 2 - r);
            GameObject sphere = Instantiate(pre_sphere);
            sphere.transform.position = new Vector3(x,y,z);
            sphere.transform.parent = kidney.transform;
            sphere.GetComponent<Renderer>().material = materials[Random.Range(0, 3)];
            sphere.tag = "Bubble";
        }
    }
}
