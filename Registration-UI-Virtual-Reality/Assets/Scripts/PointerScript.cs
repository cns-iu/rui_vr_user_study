using UnityEngine;
using UnityEngine.EventSystems;

public class PointerScript : MonoBehaviour
{
    public float defaultLength = 5.0f;
    public GameObject dot;
    public VRInputModule InputModule;

    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        //use default or distance 
        PointerEventData data = InputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

        //Raycast
        RaycastHit hit = CreateRayCast(targetLength);

        //default end
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        //or based on hit
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }

        //set position of dot
        dot.transform.position = endPosition;

        //set position of line renderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRayCast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }
}
