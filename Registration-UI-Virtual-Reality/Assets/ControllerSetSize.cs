using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class ControllerSetSize : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public SteamVR_Action_Boolean touchpadUpAction;
    public SteamVR_Action_Boolean touchpadDownAction;

    [SerializeField]
    GameObject sliver;
    [SerializeField]
    Toggle[] buttons;

    private void Start()
    {
        touchpadUpAction.AddOnStateDownListener(delegate
        {
            SetSize(GetActiveButton(), "up");
            Debug.Log("Touchpad up: " + GetActiveButton());
        }, handType);

        touchpadDownAction.AddOnStateDownListener(delegate
        {
            SetSize(GetActiveButton(), "down");
            Debug.Log("Touchpad down: " + GetActiveButton());
        }, handType);

    }

    void SetSize(int activeButton, string dir) {

        switch (activeButton)
        {
            case 0:
                if (dir == "up")
                {
                    sliver.transform.localScale += new Vector3(.01f, 0f, 0f);
                }
                else
                {
                    sliver.transform.localScale += new Vector3(-.01f, 0f, 0f);
                }
                break;
            case 1:
                if (dir == "up")
                {
                    sliver.transform.localScale += new Vector3(0, .01f, 0f);
                }
                else
                {
                    sliver.transform.localScale += new Vector3(0f, -.01f, 0f);
                }
                break;
            case 2:
                if (dir == "up")
                {
                    sliver.transform.localScale += new Vector3(0, 0f, .01f);
                }
                else
                {
                    sliver.transform.localScale += new Vector3(0f, 0f, -.01f);
                }
                break;
            default:
                break;
        }
    }

    int GetActiveButton() {
        int activeButton = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].isOn)
            {
                activeButton = i;
            }
        }
        return activeButton;
    }
}
