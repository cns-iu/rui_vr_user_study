using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public float defaultLength = 5f;
    public GameObject dot;
    public VRInputModule inputModule;

    LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLine();
    }

    void UpdateLine()
    {
        // use default val for length
        PointerEventData data = inputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;
        //Debug.Log(targetLength);

        //raycast
        RaycastHit hit = CreateRayCast(targetLength);

        //set up default end
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        //or based on hit
        if (hit.collider)
        {
            endPosition = hit.point;
        }

        // set position of dot
        dot.transform.position = endPosition;

        //set positions of line renderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    RaycastHit CreateRayCast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }
}
