using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTutorialVisibility : MonoBehaviour
{

    public GameObject arrow;
    private void OnEnable()
    {
        ControllerGrabObject.GrabEvent += Disappear;
    }

    private void OnDisable()
    {
        ControllerGrabObject.GrabEvent -= Disappear;
    }

    // Update is called once per frame
    void Disappear()
    {
        gameObject.SetActive(false);
        arrow.gameObject.SetActive(false);
    }
}
