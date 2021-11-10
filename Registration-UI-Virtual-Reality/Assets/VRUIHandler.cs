using UnityEngine;
using UnityEngine.UI;

public class VRUIHandler : MonoBehaviour
{
    //public vars to get UI elements
    public Text xRot;
    public Text yRot;
    public Text zRot;
    public Text xPos;
    public Text yPos;
    public Text zPos;
    public Text targetXPos;
    public Text targetYPos;
    public Text targetZPos;
    public Text targetXRot;
    public Text targetYRot;
    public Text targetZRot;
    public Text distance;
    public Text differenceRot;
    public Text startSequence;
    public Text randomSequence;
    public Text currentSliver;

    public TaskManager tm;
    public Transform sliver;
    public Transform target;
    public DataLogger dl;

    public GameObject warning;

    private void Start()
    {
        UpdateSliverVariable();
    }

    private void OnEnable()
    {
        TaskManager.TaskUpdateEvent += UpdateSliverVariable;

    }

    private void OnDisable()
    {
        TaskManager.TaskUpdateEvent -= UpdateSliverVariable;
    }

    void UpdateSliverVariable()
    {
        sliver = tm.currentSliver.transform;
        target = tm.currentTarget.transform;
        //Debug.Log(sliver.name);
        //Debug.Log(target.name);
        //Debug.Log("VRUIHandler called UpdateSliverVariable(), got the following: " + sliver);
    }

    void Update()
    {
        xPos.text = "x position: " + sliver.position.x.ToString("F2");
        yPos.text = "y position: " + sliver.position.y.ToString("F2");
        zPos.text = "z position: " + sliver.position.z.ToString("F2");
        xRot.text = "x rotation: " + sliver.rotation.eulerAngles.x.ToString("F0");
        yRot.text = "y rotation: " + sliver.rotation.eulerAngles.y.ToString("F0");
        zRot.text = "z rotation: " + sliver.rotation.eulerAngles.z.ToString("F0");

        targetXPos.text = "x position: " + target.position.x.ToString("F2");
        targetYPos.text = "y position: " + target.position.y.ToString("F2");
        targetZPos.text = "z position: " + target.position.z.ToString("F2");
        targetXRot.text = "x rotation: " + target.rotation.eulerAngles.x.ToString("F0");
        targetYRot.text = "y rotation: " + target.rotation.eulerAngles.y.ToString("F0");
        targetZRot.text = "z rotation: " + sliver.rotation.eulerAngles.z.ToString("F0");

        startSequence.text = tm.start;
        randomSequence.text = tm.output;

        //currentSliver.text = "Current sliver: " + tm.currentSliver.name + ", num: " + System.Array.IndexOf(tm.slivers, tm.currentSliver);

        float f_distance = Vector3.Distance(sliver.transform.position, target.transform.position);
        float v3_diffRotation = Quaternion.Angle(sliver.transform.rotation, target.transform.rotation); ;
        //Vector3 v3_diffRotation = UnityEditor.TransformUtils.GetInspectorRotation(sliver.transform) - UnityEditor.TransformUtils.GetInspectorRotation(target.transform);

        distance.text = "Total distance: " + f_distance.ToString();
        differenceRot.text = "Total difference in rotation: " + v3_diffRotation.ToString();
    }

    //private void OnDrawGizmos()
    //{
    //    Debug.DrawLine(sliver.transform.position, sliver.transform.forward * 20 + sliver.transform.position);
    //    Debug.DrawLine(target.transform.position, target.transform.forward * 20 + target.transform.position);
    //}




}
