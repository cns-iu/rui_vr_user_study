using UnityEngine;
using UnityEngine.UI;

public class DragWithMouse : MonoBehaviour
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
        //SetLabelPositions();
    }

    private void OnValidate()
    {
        //SetLabelPositions();
    }

    void OnMouseDown()

    {
        //Debug.Log("mouse down over sliver");
        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;


        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseUseEvent("mouse", "left", "down");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            MouseUseEvent("mouse", "right", "down");
        }
        else if (Input.GetMouseButtonDown(2))
        {
            MouseUseEvent("mouse", "middle", "down");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MouseUseEvent("mouse", "left", "up");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            MouseUseEvent("mouse", "right", "up");
        }
        else if (Input.GetMouseButtonUp(2))
        {
            MouseUseEvent("mouse", "middle", "up");
        }
        else if (Input.mouseScrollDelta.y > 0f)
        {
            MouseUseEvent("mouse", "scroll", "up");
        }
        else if (Input.mouseScrollDelta.y < 0f)
        {
            MouseUseEvent("mouse", "scroll", "down");
        }
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
        if (preview.isOn == false)
        {
            //Debug.Log("dragging with new script");
            transform.position = GetMouseAsWorldPoint() + mOffset;
            //SetLabelPositions();
        }


    }

    public void SetLabelPositions()
    {
        visElements.transform.position = transform.position;
        yLabel.transform.position = new Vector3(
                transform.position.x - labelOffset,
                y.position.y,
                transform.position.z
            );
        y2Label.transform.position = new Vector3(
                transform.position.x,
                y.position.y,
                transform.position.z - labelOffset
            );
        xLabel.transform.position = new Vector3(
                x.position.x,
                transform.position.y + labelOffset,
                transform.position.z
            );
        zLabel.transform.position = new Vector3(
                transform.position.z,
                transform.position.y + labelOffset,
                z.position.z
            );
    }

}
