using UnityEngine;

public class OnDragMove : MonoBehaviour
{
    Camera cam;
    bool isMouseOver = false;
    Vector3 mousePos;
    StateManager stateManager;
    float tempX;
    float tempZ;

    private void Start()
    {
        cam = Camera.main;
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        Debug.Log(stateManager.currentState);
    }

    void Update()
    {
        mousePos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        MoveObject(stateManager.currentState);
    }

    private void MoveObject(CameraState state)
    {
        
        //Debug.Log("calling MoveObject() with param " + state);
        if (stateManager.currentState == CameraState.front)
        {
            
            float z = this.transform.position.z + Mathf.Abs(cam.transform.position.z);

            Vector3 newPos = cam.ScreenToWorldPoint(
                new Vector3(
                    mousePos.x,
                    mousePos.y,
                    z
                    )
                );
            this.transform.position = newPos;
            tempX = this.transform.position.x;
            Debug.Log("this.transform.position.z: " + this.transform.position.z);
            Debug.Log("Mathf.Abs(cam.transform.position.z): " + Mathf.Abs(cam.transform.position.z));
            Debug.Log("z: " + z);
        }
        else if (stateManager.currentState == CameraState.side)
        {
            Vector3 screenToWorldPos = cam.ScreenToWorldPoint(
                new Vector3(
                    mousePos.x,
                    mousePos.y,
                    tempX
                    )
                );
            Vector3 newPos = new Vector3(
                    tempX,
                    screenToWorldPos.y,
                    screenToWorldPos.z  
                    //+ -9.350159f
                );
            this.transform.position = newPos;
            tempZ = this.transform.position.z;

        }
        else if (stateManager.currentState == CameraState.preview)
        {
            Debug.Log("doing nothing");
        }



    }
}
