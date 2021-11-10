using UnityEngine;
using UnityEngine.UI;


public class CameraControl : MonoBehaviour
{

    public delegate void CameraPreview(bool isPreviewOn);
    public static event CameraPreview CameraPreviewEvent;
    public GameObject yLine;
    public CanvasGroup posReset;
    public CanvasGroup posText;
    public CanvasGroup previewClose;
    public CanvasGroup cameraToggle;
    public GameObject previewToggleImage;
    public Image closeButton;
    public Image eyeIcon;
    public Transform kidney;

    public Text previewText;

    public Transform target;

    public Slider[] sliders = new Slider[3];

    private Vector3 _cameraOffset;

    bool isCameraMovementAllowed = true;

    [Range(.01f, 1f)]
    public float smoothFactor = .5f;

    public Toggle preview;

    public float rotationSpeed = .5f;

    //public GameObject slider;

    public float panSpeed = 1f;
    public Vector3 prevMNousePos;

    public GameObject sm;
    StateManager stateManager;

    public Transform gizmo;

    void OnEnable()
    {
        StateManager.OnTogglePreview += TogglePreview;
    }


    void OnDisable()
    {
        StateManager.OnTogglePreview -= TogglePreview;
    }

    void Start()
    {
        _cameraOffset = this.transform.position - target.transform.position;
        prevMNousePos = Input.mousePosition;
        stateManager = sm.GetComponent<StateManager>();
    }

    public void CheckSliders(bool isSliderUsed)
    {
        isCameraMovementAllowed = !isSliderUsed;
    }



    void TogglePreview(bool isPreviewOn)
    {
        eyeIcon.GetComponent<Image>().gameObject.SetActive(!isPreviewOn);
        closeButton.GetComponent<Image>().gameObject.SetActive(isPreviewOn);
        if (isPreviewOn)
        {
            this.gameObject.GetComponent<Camera>().depth = 0;
            previewText.text = "<b>3D Preview</b>";
        }
        else
        {
            this.gameObject.GetComponent<Camera>().depth = -2;
            previewText.text = "3D Preview";
        }
        ToggleUIElements(isPreviewOn);
    }

    void ToggleUIElements(bool isPreviewOn)
    {
        yLine.GetComponent<LineRenderer>().enabled = !isPreviewOn;
        //posReset.GetComponent<CanvasGroup>().interactable = !isPreviewOn;
        cameraToggle.interactable = !isPreviewOn;
        cameraToggle.alpha = System.Convert.ToSingle(!isPreviewOn);

        //if (isPreviewOn)
        //{
        //    posReset.GetComponent<CanvasGroup>().alpha = 0f;
        //    posText.GetComponent<CanvasGroup>().alpha = 0f;
        //}
        //else
        //{
        //    posReset.GetComponent<CanvasGroup>().alpha = 1f;
        //    posText.GetComponent<CanvasGroup>().alpha = 1f;
        //}
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (preview.isOn)
        {
            if (isCameraMovementAllowed)
            {
                if (Input.GetMouseButton(0))
                {
                    Quaternion camTurnAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
                    Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, Vector3.forward);
                    _cameraOffset = camTurnAngleY * camTurnAngleX * _cameraOffset;
                    Vector3 newPos = target.position + _cameraOffset;
                    this.transform.position = Vector3.Slerp(this.transform.position, newPos, smoothFactor);
                }
                if (Input.mouseScrollDelta != new Vector2(0f,0f))
                {
                    this.GetComponent<Camera>().fieldOfView -= Input.mouseScrollDelta.y;
                }
                this.transform.LookAt(target.transform);
            }
            
        }
        gizmo.transform.rotation = kidney.transform.rotation;
        //gizmo.transform.Rotate(180f, 0f, 0f);
    }
}

