using UnityEngine;

public class AngleAdjustmentUtils : MonoBehaviour
{

    public Transform target;
    public Transform sliver;

    private void Update()
    {
        float angle = Quaternion.Angle(transform.rotation, sliver.transform.rotation);
        //angleFromVector3 = Vector3.Angle(transform.position, target.transform.position);

        //Debug.Log("distances: " + distances[0] + ", " + distances[1] + "," + distances[2]);
        Debug.Log("Quaternion.Angle between objects: " + angle);
        //t.text = "Angle: " + angle.ToString("F1");
        //Debug.Log("angleFromVector3: " + angleFromVector3);

    }
}
