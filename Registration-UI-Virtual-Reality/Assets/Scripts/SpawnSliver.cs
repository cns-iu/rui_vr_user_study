using UnityEngine;

public class SpawnSliver : MonoBehaviour
{
    public GameObject pre_sliver;
    private Transform kidney;
    public bool rotateSliver = false;
    public Material mat_gizmoBox;

    public Vector3 sliverSpawnPos;
    public Vector3 sliverSpawnRot;
    private float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        kidney = this.transform;
        float spawnX, spawnY, spawnZ;
        float lengthByTwo = pre_sliver.transform.localScale.x / 2;
        spawnX = kidney.position.x + Random.Range(
                -kidney.localScale.x / 2 + lengthByTwo, kidney.localScale.x / 2 - lengthByTwo);
        spawnY = kidney.position.y + Random.Range(
                -kidney.localScale.y / 2 + lengthByTwo, kidney.localScale.y / 2 - lengthByTwo);
        spawnZ = kidney.position.z + Random.Range(
                -kidney.localScale.z / 2 + lengthByTwo, kidney.localScale.z / 2 - lengthByTwo);

        GameObject sliver = Instantiate(pre_sliver, new Vector3(spawnX, spawnY, spawnZ), kidney.rotation);
        //GameObject sliverGizmo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //sliverGizmo.transform.position = sliver.transform.position;
        //sliverGizmo.transform.localScale = sliver.transform.localScale;
        //sliverGizmo.GetComponent<Renderer>().material = mat_gizmoBox;

        if (rotateSliver)
        {
            x = Random.Range(-179, 180);
            y = Random.Range(-179, 180);
            z = Random.Range(-179, 180);
            sliver.transform.Rotate(new Vector3(
               x,
               y,
               z
               ));
        }

        sliverSpawnPos = sliver.transform.position;
        sliverSpawnRot = new Vector3(
           sliver.transform.rotation.x,
           sliver.transform.rotation.y,
           sliver.transform.rotation.z
            );
        //Debug.Log(Quaternion.Euler(sliverSpawnRot));
    }
}
