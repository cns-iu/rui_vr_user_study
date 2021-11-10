using UnityEngine;

public class SetWarning : MonoBehaviour
{
    public GameObject warning;
    public GameObject endOfSessionMessage;

    //private void OnEnable()
    //{
    //    ControllerGrabObject.GrabEvent += SetVisibilityFalse;
    //}

    //private void OnDisable()
    //{
    //    TaskManager.TaskUpdateEvent -= SetVisibilityTrue;
    //}

    private void Start()
    {
        ControllerGrabObject.GrabEvent += SetVisibilityFalse;
        TaskManager.TaskUpdateEvent += SetVisibilityTrue;
        TaskManager.EndOfSessionEvent += SetEndOfSessionMessage;
    }

    void SetVisibilityTrue()
    {
        //Debug.Log("warning set to active");
        warning.gameObject.SetActive(true);
        
    }

    void SetVisibilityFalse()
    {
        warning.gameObject.SetActive(false);
        //Debug.Log("warning set to NOT active");
    }

    void SetEndOfSessionMessage() {
        endOfSessionMessage.gameObject.SetActive(true);
    }
}
