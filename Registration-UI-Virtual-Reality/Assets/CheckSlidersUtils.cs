using UnityEngine;
using UnityEngine.UI;

public class CheckSlidersUtils : MonoBehaviour
{
    public CameraControl cc;
    public Slider[] sliders = new Slider[3];

    private void Start()
    {
        foreach (var item in sliders)
        {
            item.onValueChanged.AddListener(delegate
            {
                //cc.isCameraMovementAllowed = false;
            });
        }
    }

   
}
