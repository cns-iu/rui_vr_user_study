using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionOnState : MonoBehaviour
{
    Vector3 startPos;
    AppState changeToState;

    private void OnEnable()
    {
        GlobalStateManager.SceneButtonClick += IdentifyNewState;
    }

    private void OnDisable()
    {
        GlobalStateManager.SceneButtonClick -= IdentifyNewState;
    }

    private void Awake()
    {
        startPos = this.transform.position;
    }

    void IdentifyNewState(AppState oldState, int i) {
        switch (oldState)
        {
            case AppState.CheckIn:
                changeToState = AppState.Registration;
                SetPosition(changeToState);
                break;
            case AppState.Registration:
                if (i == 1)
                {
                    //Debug.Log("calling with i = " + i);
                    changeToState = AppState.CheckIn;
                    //Debug.Log("going back");
                }
                else if (i == 2)
                {
                    //Debug.Log("calling with i = " + i);
                    changeToState = AppState.Submission;
                    //Debug.Log("going forward");
                }
                SetPosition(changeToState);
                break;
            case AppState.Submission:
                if (i == 2)
                {
                    changeToState = AppState.CheckIn;
                }
                else
                {
                    changeToState = AppState.Registration;
                }
                SetPosition(changeToState);
                break;
            default:
                break;
        }
    }

    void SetPosition(AppState newState) {
        if (newState == AppState.CheckIn || newState == AppState.Submission)
        {
            this.transform.position = startPos;
        }
        else
        {
            this.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(21f, -505.2f, 0f);
        }

        
    }
}
