using UnityEngine;
using UnityEngine.UI;

public class UIInputListener : MonoBehaviour
{
    public delegate void ButtonPress(string btn, string si, string stat);
    public static event ButtonPress ButtonPressEvent;



    public Button btnResetPos;
    public Button btnResetRot;
    public Button btnNext;
    public Toggle toggleSwitch;
    public Toggle togglePreview;
    public Slider[] sliders = new Slider[3];

    private void OnEnable()
    {
        TaskManager.TaskUpdateEvent += ResetSliders;
    }

    private void OnDisable()
    {
        TaskManager.TaskUpdateEvent -= ResetSliders;
    }

    void ResetSliders()
    {
        foreach (var item in sliders)
        {
            item.value = 0f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        btnResetPos.onClick.AddListener(delegate
        {
            if (ButtonPressEvent != null)
            {
                ButtonPressEvent("resetPos", "", "pressed");
            }
        });
        btnResetRot.onClick.AddListener(delegate
        {
            if (ButtonPressEvent != null)
            {
                ButtonPressEvent("resetRot", "", "pressed");
            }
        });
        btnNext.onClick.AddListener(delegate
        {
            if (ButtonPressEvent != null)
            {
                ButtonPressEvent("next", "", "pressed");
            }
        });
        toggleSwitch.onValueChanged.AddListener(delegate
        {
            if (ButtonPressEvent != null)
            {
                if (toggleSwitch.isOn)
                {
                    ButtonPressEvent("mainCameraAngle", "frontToSide", "pressed");
                }
                else
                {
                    ButtonPressEvent("mainCameraAngle", "sideToFront", "pressed");
                }
            }

        });
        togglePreview.onValueChanged.AddListener(delegate
        {
            if (ButtonPressEvent != null)
            {
                if (togglePreview.isOn)
                {
                    ButtonPressEvent("previewCamera", "turnOn", "pressed");
                }
                else
                {
                    ButtonPressEvent("previewCamera", "turnOff", "pressed");
                }
            }

        });
    }
}
