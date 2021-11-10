using UnityEngine;
using UnityEngine.UI;

public enum CameraState { front, side, preview }

public class StateManager : MonoBehaviour
{
    public CameraState currentState = CameraState.front;
    public GameObject cam;
    //public Slider rotSlider;
    public Toggle frontView;
    public Toggle sideView;
    public Toggle topView;
    public Toggle preview;
    public Toggle viewSwitchToggle;
    public Text front;
    public Text side;
    public Button closePreviewCamera;
    public Sprite close;
    public delegate void MoveAction(CameraState newState);
    public static event MoveAction OnClickedMove;
    public delegate void TogglePreview(bool isPreviewOn);
    public static event TogglePreview OnTogglePreview;
    public Camera secondCamera;
    public Transform frontPos;
    public Transform sidePos;

    // Update is called once per frame
    void Start()
    {
        front.text = "<b>Front</b>";
        viewSwitchToggle.onValueChanged.AddListener(
            delegate
            {
                if (OnClickedMove != null)
                {
                    if (viewSwitchToggle.isOn)
                    {
                        //Debug.Log("to side");
                        OnClickedMove(CameraState.front);
                        //Debug.Log("to side");
                        side.text = "<b>Side</b>";
                        front.text = "Front";
                    }
                    else
                    {
                        OnClickedMove(CameraState.side);
                        //Debug.Log("to front");
                        side.text = "Side";
                        front.text = "<b>Front</b>";
                    }


                }
            });

        preview.onValueChanged.AddListener(delegate
        {
            //ToggleValueChanged(preview);
            if (OnTogglePreview != null)
            {
                OnTogglePreview(preview.isOn);
                //preview.GetComponent<Image>().sprite = close.sprite;
            }

           
        });

        closePreviewCamera.onClick.AddListener(
            delegate {
                preview.isOn = false;
            });


        //frontView.onValueChanged.AddListener(delegate
        //{
        //    ToggleValueChanged(frontView);
        //    if (frontView.isOn)
        //    {
        //        if (OnClickedMove != null)
        //        {
        //            OnClickedMove(CameraState.front);
        //        }
        //        if (OnTogglePreview != null)
        //        {
        //            OnTogglePreview();
        //        }
        //    }

        //});
        //sideView.onValueChanged.AddListener(delegate
        //{
        //    ToggleValueChanged(sideView);
        //    if (sideView.isOn)
        //    {
        //        if (OnClickedMove != null)
        //        {
        //            OnClickedMove(CameraState.side);
        //        }
        //        if (OnTogglePreview != null)
        //        {
        //            OnTogglePreview();
        //        }
        //    }

        //});

        //}

        //void ToggleValueChanged(Toggle toggle)
        //{
        //    ////Debug.Log("change detected");
        //    //if (toggle == frontView)
        //    //{
        //    //    if (toggle.isOn)
        //    //    {
        //    //        currentState = CameraState.front;
        //    //    }
        //    //    //Debug.Log("toggle is " + toggle);
        //    //}
        //    //else if (toggle == sideView)
        //    //{
        //    //    if (toggle.isOn)
        //    //    {
        //    //        currentState = CameraState.side;
        //    //    }
        //    //    //Debug.Log("toggle is " + toggle);
        //    //}
        //    //else 
        //    if (toggle == preview)
        //    {
        //        if (toggle.isOn)
        //        {
        //            currentState = CameraState.preview;
        //        }
        //    }
        //}
    }
}

