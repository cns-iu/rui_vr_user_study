using UnityEngine;
using UnityEngine.UI;

public class DesktopUtils : MonoBehaviour
{

    public TaskManager tm;
    public DistanceTool dt;
    public Toggle t;
    public GameObject cubeVisElements;
    public Transform y;
    public Transform x;
    public Transform z;
    public GameObject xlabel;
    public GameObject yLabel;
    public GameObject y2Label;
    public GameObject zLabel;

    private void OnEnable()
    {
        TaskManager.BeginningOfSessionEvent += AddDragWithMouseComponentOnSpawn;
        //TaskManager.TaskUpdateEvent += PrintGeometricInfo;
    }

    private void OnDisable()
    {
        TaskManager.BeginningOfSessionEvent -= AddDragWithMouseComponentOnSpawn;
        //TaskManager.TaskUpdateEvent += PrintGeometricInfo;
    }
    
    public void AddDragWithMouseComponentOnSpawn()
    {

        foreach (var item in tm.slivers)
        {
            item.AddComponent(typeof(DragWithMouse));
            DragWithMouse dm = item.GetComponent<DragWithMouse>();
            dm.preview = t;
            //dm.visElements = cubeVisElements;
            //dm.y = y;
            //dm.x = x;
            //dm.z = z;
            //dm.xLabel = xlabel;
            //dm.yLabel = yLabel;
            //dm.y2Label = y2Label;
            //dm.zLabel = zLabel;
            //dm.labelOffset = .3f;
            //dm.SetLabelPositions();
        }
    }
}
