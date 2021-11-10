using UnityEngine;
using UnityEngine.UI;

public class MoveWithMouse : MonoBehaviour
{
    private Vector3 mOffset;
    public StateManager sm;
    public Toggle preview;

    public GameObject visElements;
    public Transform y;
    public Transform x;
    //public Transform y2;
    public Transform z;
    public GameObject xLabel;
    public GameObject yLabel;
    public GameObject y2Label;
    public GameObject zLabel;

    public float labelOffset;


    private float mZCoord;

    public delegate void MouseUse(string key, string hand, string status);
    public static event MouseUse MouseUseEvent;



    private void Awake()
    {
        SetLabelPositions();
    }

    private void OnValidate()
    {
        SetLabelPositions();
    }

    void OnMouseDown()

    {
        //Debug.Log("mouse down over sliver");
        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;


        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;


        // z coordinate of game object on screen

        mousePoint.z = mZCoord;


        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()

    {
        //Debug.Log("isDragged");
        //Debug.Log("dragging mouse");
        //if (preview.isOn == false)
        //{
        //Debug.Log("dragging");
        //Debug.Log("dragging with new script");
        if (preview.isOn == false)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }

        SetLabelPositions();
        //}


    }

    public void SetLabelPositions()
    {
        visElements.transform.position = transform.position;
        //xLabel.transform.position = new Vector3(
        //        transform.position.x - labelOffset,
        //        y.position.y,
        //        transform.position.z
        //    );
        //y2Label.transform.position = new Vector3(
        //        transform.position.x,
        //        y.position.y,
        //        transform.position.z - labelOffset
        //    );
        //xLabel.transform.position = new Vector3(
        //        x.position.x,
        //        transform.position.y + labelOffset,
        //        transform.position.z
        //    );
        //zLabel.transform.position = new Vector3(
        //        transform.position.z,
        //        transform.position.y + labelOffset,
        //        z.position.z
        //    );
    }
}
