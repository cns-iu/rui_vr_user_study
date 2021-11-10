using UnityEngine;
using UnityEngine.UI;

public class AngleExample : MonoBehaviour
{
    public Transform sliver;
    float[] distances = new float[3];
    float angle;
    float angleFromVector3;
    Transform[] cubeHandles = new Transform[3];
    Transform[] sphereHandles = new Transform[3];

    public Transform finalRotation;

    public Text t;
    public bool showQuaternionAngle = false;
    public bool showAnglesBetweenExternalLines = false;

    public float x;
    public float y;
    public float z;

    float count;

    private void Start()
    {
        // Sets the transform's current rotation to a new rotation that rotates 30 degrees around the y-axis(Vector3.up)

    }

    private void OnValidate()
    {
        transform.rotation = Quaternion.AngleAxis(x, new Vector3(1f, 0f, 0f));
        transform.rotation = Quaternion.AngleAxis(y, new Vector3(0f, 1f, 0f));
        transform.rotation = Quaternion.AngleAxis(z, Vector3.forward);
        //Debug.Log(Quaternion.Angle(transform.rotation, Quaternion.Inverse(transform.rotation)));
        //Debug.Log(Quaternion.Inverse(transform.rotation).eulerAngles);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            count++;
            transform.rotation = Quaternion.Slerp(sliver.rotation, finalRotation.rotation, count/14f);
            Debug.Log("between target and final: " + Quaternion.Angle(transform.rotation, finalRotation.rotation));
            Debug.Log("between target and sliver: " + Quaternion.Angle(transform.rotation, sliver.rotation));
        }

        //transform.rotation = Quaternion.AngleAxis(20, Vector3.up);
        if (showQuaternionAngle)
        {
            //for (int i = 0; i < cubeHandles.Length; i++)
            //{
            //    cubeHandles[i] = transform.GetChild(i);
            //    sphereHandles[i] = sliver.transform.GetChild(i);
            //    distances[i] = Vector3.Distance(cubeHandles[i].position, sphereHandles[i].position);

            //}

            angle = Quaternion.Angle(transform.rotation, sliver.transform.rotation);
            //angleFromVector3 = Vector3.Angle(transform.position, target.transform.position);

            //Debug.Log("distances: " + distances[0] + ", " + distances[1] + "," + distances[2]);
            //Debug.Log("Quaternion.Angle() between objects: " + angle);
            //Debug.Log("EulerAngles: " + transform.rotation.eulerAngles);
            //Debug.Log(Quaternion.Dot(transform.rotation,sliver.rotation));
            t.text = "Angle: " + angle.ToString("F1");
            //Debug.Log("angleFromVector3: " + angleFromVector3);
        }
        else if (showAnglesBetweenExternalLines)

        {
            Debug.Log(
                Vector3.Angle(transform.position - transform.GetChild(3).transform.position,
                sliver.transform.position - sliver.transform.GetChild(3).transform.position
                ) + ", " +
                Vector3.Angle(transform.position - transform.GetChild(4).transform.position,
                sliver.transform.position - sliver.transform.GetChild(4).transform.position
                ) + ", " +
                Vector3.Angle(transform.position - transform.GetChild(5).transform.position,
                sliver.transform.position - sliver.transform.GetChild(5).transform.position
                )
            );
        }
        else
        {
            Vector3 relativePos = sliver.position - transform.position;

            // the second argument, upwards, defaults to Vector3.up
            //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
            Quaternion rotTarget = transform.rotation;
            Quaternion rotSliver = sliver.transform.rotation;
            //Debug.Log("target: " + rotTarget.eulerAngles);
            //Debug.Log("sliver: " + rotSliver.eulerAngles);

            //transform.rotation = rotSliver;
            //transform.rotation = rotation;
        }

        //Debug.Log("Target: " + 
        //    UnityEditor.TransformUtils.GetInspectorRotation(this.transform)
        //    );
        //Debug.Log("Sliver: " +
        //    UnityEditor.TransformUtils.GetInspectorRotation(target.transform)
        //    );
        //Debug.Log("Target: " +
        //    transform.localEulerAngles
        //    );



    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.GetChild(3).position, Color.red);
        Debug.DrawLine(sliver.transform.position, sliver.transform.GetChild(3).position, Color.red);
        Debug.DrawLine(finalRotation.transform.position, finalRotation.transform.GetChild(3).position, Color.red);

        Debug.DrawLine(transform.position, transform.GetChild(4).position, Color.green);
        Debug.DrawLine(sliver.transform.position, sliver.transform.GetChild(4).position, Color.green);
        Debug.DrawLine(finalRotation.transform.position, finalRotation.transform.GetChild(4).position, Color.green);

        Debug.DrawLine(transform.position, transform.GetChild(5).position, Color.blue);
        Debug.DrawLine(sliver.transform.position, sliver.transform.GetChild(5).position, Color.blue);
        Debug.DrawLine(finalRotation.transform.position, finalRotation.transform.GetChild(5).position, Color.blue);

        //Debug.DrawLine(transform.position, transform.position + new Vector3(10,10,10));
        //Debug.DrawLine(sliver.transform.position, sliver.transform.position + new Vector3(10, 10, 10));

        //Debug.DrawLine(transform.position, transform.forward * 20 + transform.position, Color.blue);
        //Debug.DrawLine(sliver.transform.position, sliver.transform.forward * 20 + sliver.transform.position, Color.blue);
    }


}
