using System.Collections;
using UnityEngine;

public class SetCameraRotationPositionOnState : MonoBehaviour
{
    public Transform frontPos;
    public Transform sidePos;
    public Transform topPos;
    public StateManager sm;
    public float duration;
    float counter = 0;

    void OnEnable()
    {
        StateManager.OnClickedMove += Teleport;
    }


    void OnDisable()
    {
        StateManager.OnClickedMove -= Teleport;
    }


    void Teleport(CameraState newState)
    {
        if (newState == CameraState.side)
        {
            //Debug.Log("going to side");
            StartCoroutine(MoveCamera(transform.position, sidePos.position, transform.rotation, sidePos.rotation));
        }
        else if (newState == CameraState.front)
        {
            //Debug.Log("going to front");
            StartCoroutine(MoveCamera(transform.position, frontPos.position, transform.rotation, frontPos.rotation));
        }
        //Debug.Log(transform.position);
        //Debug.Log(transform.rotation.eulerAngles);
    }

    public IEnumerator MoveCamera(Vector3 from, Vector3 to, Quaternion startAngle, Quaternion endAngle)
    {
        //Debug.Log(counter);
        //Debug.Log("executing soroutine");
        while (counter <= duration)
        {
            //Debug.Log(transform.eulerAngles);
            this.transform.position = Vector3.Lerp(
                from,
                to,
                counter / duration
            );
            //Debug.Log(counter);
            //Debug.Log(duration);
            transform.rotation = Quaternion.Slerp(
                startAngle,
                endAngle, 
                 counter/duration);
            //Debug.Log("yielding now");
            counter += Time.deltaTime;
            //Debug.Log(Time.deltaTime);
            yield return null;
        }
        //Debug.Log(counter);
        counter = 0;
    }

}
