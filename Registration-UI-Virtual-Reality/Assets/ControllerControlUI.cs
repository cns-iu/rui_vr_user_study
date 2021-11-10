using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ControllerControlUI : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean menuAction;


    //Color foreground = new Color(255, 227, 0, 255);
    //Color background = new Color(255, 227, 0, 80);

    [SerializeField]
    Canvas ca;
    [SerializeField]
    GameObject[] gog;
    [SerializeField]
    Text tooltipRight;
    //[SerializeField]
    //GameObject panelRight;
    [SerializeField]
    Text tooltipLeft;
    //[SerializeField]
    //GameObject panel;
    int[] counters = new int[2];

    public delegate void ControllerUse(string key, string hand, string status);
    public static event ControllerUse ControllerUseEvent;

    // Update is called once per frame
    void Start()
    {
        counters[0] = 1;
        counters[1] = 1;
        menuAction.AddOnStateDownListener(delegate
        {
            if (ControllerUseEvent != null) ControllerUseEvent("menu", handType.ToString(), "down");
            counters[0]++;
            counters[1]++;
            SetUIVisibility(handType, counters[0]);
        }, handType);

        menuAction.AddOnStateUpListener(delegate
        {
            if (ControllerUseEvent != null) ControllerUseEvent("menu", handType.ToString(), "up");
        }, handType);

    }

    void SetUIVisibility(SteamVR_Input_Sources hand, int counter)
    {
        switch (hand)
        {
            case SteamVR_Input_Sources.LeftHand:
                //Debug.Log("This code is exected with " + hand);
                ca.gameObject.SetActive(CheckIfOdd(counters[0]));
                if (CheckIfOdd(counters[0])) tooltipLeft.text = "Press to hide data";
                else
                {
                    tooltipLeft.text = "Press to show data";
                }
                //counters[0]++;
                break;
            case SteamVR_Input_Sources.RightHand:

                for (int i = 0; i < gog.Length; i++)
                {
                    gog[i].gameObject.SetActive(CheckIfOdd(counters[1]));
                }
                if (CheckIfOdd(counters[1]))
                {
                    tooltipRight.text = "Press to hide tooltips";
                    //tooltipRight.color = foreground;
                    //panelRight.GetComponent<Image>().color = new Color(0,0,0,255);
                }
                else
                {
                    tooltipRight.text = "Press to show tooltips";
                    //tooltipRight.color = background;
                    //panelRight.GetComponent<Image>().color = new Color(0, 0, 0, 50);
                }
                //counters[1]++;
                break;
            default:
                break;
        }
    }

    bool CheckIfOdd(int counter)
    {
        return counter % 2 != 0;
    }
}
