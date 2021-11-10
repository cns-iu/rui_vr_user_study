using UnityEngine;

public class GetGeometry : MonoBehaviour
{
    public GameObject[] organs;
    //public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        //Mesh mesh = colon.GetComponent<MeshFilter>().mesh;
        ////Debug.Log();

        //foreach (var v in mesh.vertices)
        //{
        //    Debug.Log(v);
        //}

        foreach (var item in organs)
        {
            var numTriangles = item.GetComponent<MeshFilter>().mesh.vertexCount;
            Debug.Log(item.name + " contains " + numTriangles + " vertices.");
        }
        

        //Vector3[] vertexPositions = colon.GetComponent<MeshFilter>().mesh.vertices;


        //for (int i = 0; i < vertexPositions.Length; i++)
        //{
        //    Vector3 worldPt = transform.TransformPoint(vertexPositions[i]);
        //    Instantiate(sphere, worldPt, Quaternion.identity);
        //}

        //foreach (var item in colon.GetComponent<MeshFilter>().mesh.vertices)
        //{
        //    Vector3 pos = colon.GetComponent<MeshFilter>().mesh.vertices[]
        //    Instantiate(sphere, item.x);
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }
}
