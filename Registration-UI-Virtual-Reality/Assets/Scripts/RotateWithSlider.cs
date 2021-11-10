using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateWithSlider : MonoBehaviour
{
    public Slider rotSlider;
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;
    public StateManager sm;
    public GameObject sliver;
    public bool isResetSelectiveByState = true;
    public bool isRotationRestrictedByState = false;
    public GameObject sliverStartPos;
    //public Transform frontPos;
    //public Transform sidePos;

    void Update()
    {
        SetRotationByState(sm.currentState);
    }

    void SetRotationByState(CameraState state) {
        bool isKidney = (this.gameObject.name == "Kidney");
        switch (state)
        {
            case CameraState.front:
                if (isKidney)
                {
                    SetRotation(this.gameObject, -rotSlider.value);
                }
                else
                {
                    if (isRotationRestrictedByState)
                    {
                        xSlider.interactable = false;
                        ySlider.interactable = false;
                        zSlider.interactable = true;
                    }
                    SetRotation(this.gameObject, xSlider.value, ySlider.value, zSlider.value);
                }
                break;
            case CameraState.side:
                if (isKidney)
                {
                    SetRotation(this.gameObject, 0f);
                    rotSlider.value = 0f;
                }
                else
                {
                    float tempX = this.gameObject.transform.rotation.x;
                    SetRotation(this.gameObject, xSlider.value, ySlider.value, zSlider.value);
                    if (isRotationRestrictedByState)
                    {
                        zSlider.interactable = false;
                        xSlider.interactable = true;
                        ySlider.interactable = false;
                    }
                   
                }
                break;
            default:
                break;
        }
    }

    void SetRotation(GameObject go, float yRot) {
        go.transform.rotation = Quaternion.Euler(new Vector3(0f, yRot, 0f));
    }

    void SetRotation(GameObject go, float xRot, float yRot, float zRot) {
        go.transform.rotation = Quaternion.Euler(
            new Vector3(
                xRot,
                yRot,
                zRot
                ));
    }

    public void ResetRotation()
    {
        SetRotation(this.gameObject, 0f);
        if (isResetSelectiveByState)
        {
            if (sm.currentState == CameraState.front)
            {
                ResetSlider(xSlider);
                ResetSlider(ySlider);
            }
            else
            {
                ResetSlider(ySlider);
                ResetSlider(zSlider);
            }
        }
        else
        {
            ResetSlider(xSlider);
            ResetSlider(ySlider);
            ResetSlider(zSlider);
        }
      



    }

    public void ResetPosition() {
        this.transform.position = sliverStartPos.transform.position;
    }

   
    void ResetSlider(Slider slider) {
        slider.value = 0f;
    }
}
