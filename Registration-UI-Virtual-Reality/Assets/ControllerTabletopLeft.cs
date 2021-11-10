using UnityEngine;
using Valve.VR;

public enum RotationDirection { Clockwise, Counterclockwise }

public class ControllerTabletopLeft : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean touchPadLeft;
    public SteamVR_Action_Boolean touchPadRight;
    // Start is called before the first frame update

    public delegate void TouchPadSwipeAction(RotationDirection rd);
    public static event TouchPadSwipeAction TouchPadSwipeActionEvent;

    public delegate void TouchPadPressAction(string key, string hand, string status);
    public static event TouchPadPressAction TouchPadPressActionEvent;


    // Update is called once per frame
    void Update()
    {
        if (touchPadLeft.GetState(handType))
        {
            //Debug.Log("left");
            if (TouchPadSwipeActionEvent != null)
            {
                TouchPadSwipeActionEvent(RotationDirection.Counterclockwise);
            }

        }
        else if (touchPadRight.GetState(handType))
        {
            //Debug.Log("right");
            if (TouchPadSwipeActionEvent != null)
            {
                TouchPadSwipeActionEvent(RotationDirection.Clockwise);
            }
        }
        if (touchPadLeft.GetStateDown(handType))
        {
            if (TouchPadPressActionEvent != null)
            {
                TouchPadPressActionEvent("TouchPadPressLeft", "", "down");
            }
        }
        else if (touchPadRight.GetStateDown(handType))
        {
            TouchPadPressActionEvent("TouchPadPressRight", "", "down");
        }
        if (touchPadLeft.GetStateUp(handType))
        {
            if (TouchPadPressActionEvent != null)
            {
                TouchPadPressActionEvent("TouchPadPressLeft", "", "up");
            }
        }
        else if (touchPadRight.GetStateUp(handType))
        {
            TouchPadPressActionEvent("TouchPadPressRight", "", "up");
        }

    }
}
