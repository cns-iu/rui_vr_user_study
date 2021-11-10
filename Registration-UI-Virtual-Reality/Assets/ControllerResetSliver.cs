using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ControllerResetSliver : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean teleportAction;
    public SteamVR_Action_Boolean sideGripAction;
    public SteamVR_Action_Boolean menuAction;

    delegate void ResetTrigger(string type);
    event ResetTrigger ResetTriggerEvent;
    public Transform sliver;
    public Transform sliverStartPos;
    public Slider progressSlider;
    public float duration;
    float elapsedTime = 0;
    float counter;

    public TaskManager tm;

    public delegate void ControllerUse(string key, string hand, string status);
    public static event ControllerUse ControllerUseEvent;

    private void Start()
    {
        UpdateSliverVariable();
    }

    void UpdateSliverVariable()
    {
        sliver = tm.currentSliver.transform;
        //Debug.Log("ControllerResetSliver called UpdateSliverVariable(), got the following: " + GameObject.Find("TaskManager").GetComponent<TaskManager>().currentSliver.transform);
    }

    private void OnEnable()
    {
        TaskManager.TaskUpdateEvent += UpdateSliverVariable;
        TaskManager.BeginningOfSessionEvent += UpdateSliverVariable;
    }

    private void OnDisable()
    {
        TaskManager.TaskUpdateEvent -= UpdateSliverVariable;
        TaskManager.BeginningOfSessionEvent -= UpdateSliverVariable;
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportAction.GetLastStateDown(handType))
        {
            if (ControllerUseEvent != null) ControllerUseEvent("positionReset", handType.ToString(), "down");
            DecideOnResetType("position");
        }
        if (teleportAction.GetLastStateUp(handType))
        {

            if (ControllerUseEvent != null) ControllerUseEvent("positionReset", handType.ToString(), "up");
        }

        if (menuAction.GetLastStateDown(handType))
        {
            if (ControllerUseEvent != null) ControllerUseEvent("rotationReset", handType.ToString(), "down");
            DecideOnResetType("rotation");
        }
        if (menuAction.GetLastStateUp(handType))
        {
            if (ControllerUseEvent != null) ControllerUseEvent("rotationReset", handType.ToString(), "up");

        }

    }

    IEnumerator CountDown(string type)
    {
        progressSlider.gameObject.SetActive(true);
        //Debug.Log("beginning countdown");
        while (elapsedTime <= duration)
        {
            progressSlider.value = (elapsedTime + Time.deltaTime) / duration;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //Debug.Log("counted down");
        DecideOnResetType(type);
        //StartCoroutine(ResetPositionRotation());
        elapsedTime = 0f;
        progressSlider.value = 0f;
        progressSlider.gameObject.SetActive(false);
    }

    void DecideOnResetType(string type)
    {
        if (type == "position")
        {
            StartCoroutine(ResetPosition());
        }
        else
        {
            StartCoroutine(ResetRotation());
        }
    }

    IEnumerator ResetPosition()
    {
        Vector3 currentPos = sliver.position;

        while (counter <= duration)
        {

            sliver.position = Vector3.Lerp(
                currentPos,
                sliverStartPos.position,
                counter / duration
            );

            counter += Time.deltaTime;
            //Debug.Log(Time.deltaTime);
            yield return null;
        }
        //Debug.Log(counter);
        counter = 0;

    }

    IEnumerator ResetRotation()
    {
        //Vector3 currentPos = sliver.position;
        Quaternion currentRot = sliver.rotation;

        while (counter <= duration)
        {

            sliver.rotation = Quaternion.Slerp(
               currentRot,
               sliverStartPos.rotation,
                counter / duration);

            counter += Time.deltaTime;

            yield return null;
        }
        //Debug.Log(counter);
        counter = 0;

    }

    IEnumerator ResetSize()
    {
        Vector3 currentSize = sliver.localScale;
        Vector3 endSize = sliverStartPos.localScale;

        while (counter <= duration)
        {
            //Debug.Log(transform.eulerAngles);
            sliver.localScale = Vector3.Lerp(
                currentSize,
                endSize,
                counter / duration
            );

            counter += Time.deltaTime;
            //Debug.Log(Time.deltaTime);
            yield return null;
        }
        //Debug.Log(counter);
        counter = 0;
    }
}
