using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public enum AppState { CheckIn, Registration, Submission }

public class GlobalStateManager : MonoBehaviour
{

    public AppState appState = AppState.Registration;
    public Canvas ca;
    public Button[] buttons = new Button[7];
    public InputValidatorScript ipvs;
    public GameObject infoScreen;

    public delegate void ClickAction(AppState s, int i = 0);
    public static event ClickAction SceneButtonClick;

    public GameObject[] interfaces = new GameObject[3];
    public GameObject nihLogoWindow;
    public GameObject nihLogoScreen;
    //Vector3 prevLogoPos;
    //public Transform nihLogoInfoPos;

    //[DllImport("__Internal")]
    //private static extern bool ShowSignupScreen();

    //private void Awake()
    //{
    //    Debug.Log("IsShowSignupScreenOn" + ShowSignupScreen());
    //}

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].onClick.AddListener(delegate
        {
            if (SceneButtonClick != null && ipvs.isCheckInValid) SceneButtonClick(appState);
        });
        buttons[1].onClick.AddListener(delegate
        {
            if (SceneButtonClick != null) SceneButtonClick(appState, 1);
        });
        buttons[2].onClick.AddListener(delegate
        {
            if (SceneButtonClick != null) SceneButtonClick(appState, 2);
        });
        buttons[3].onClick.AddListener(delegate
        {
            if (SceneButtonClick != null) SceneButtonClick(appState);
        });
        buttons[4].onClick.AddListener(delegate
        {
            //Debug.Log(appState);
            if (SceneButtonClick != null)
            {
                SceneButtonClick(appState, 2);
            }
        });
        buttons[5].onClick.AddListener(delegate
        {
            //prevLogoPos = nihLogo.transform.position;
            //nihLogo.transform.position = nihLogoInfoPos.position;

            ToggleInfo(true);
        });
        buttons[6].onClick.AddListener(delegate
        {
            //nihLogo.transform.position = prevLogoPos;
            ToggleInfo(false);
        });
    }

    private void OnEnable()
    {
        SceneButtonClick += ChangeState;
    }

    private void OnDisable()
    {
        SceneButtonClick -= ChangeState;
    }

    void ChangeState(AppState s, int i)
    {
        //Debug.Log("The current state is: " + s);

        switch (s)
        {
            case AppState.CheckIn:
                appState = AppState.Registration;
                ChangeUI(appState);
                break;
            case AppState.Registration:
                if (i == 1)
                {
                    //Debug.Log("calling with i = " + i);
                    appState = AppState.CheckIn;
                    //Debug.Log("going back");
                }
                else if (i == 2)
                {
                    //Debug.Log("calling with i = " + i);
                    appState = AppState.Submission;
                    //Debug.Log("going forward");
                }
                ChangeUI(appState);
                break;
            case AppState.Submission:


                appState = AppState.Registration;

                ChangeUI(appState);
                break;
            default:
                break;
        }
    }

    void ChangeUI(AppState s)
    {
        //Debug.Log("Changing UI to the one for " + appState);
        switch (s)
        {
            case AppState.CheckIn:
                interfaces[0].SetActive(true);
                interfaces[1].SetActive(false);
                interfaces[2].SetActive(false);
                break;
            case AppState.Registration:
                interfaces[1].SetActive(true);
                interfaces[0].SetActive(false);
                interfaces[2].SetActive(false);
                break;
            case AppState.Submission:
                interfaces[2].SetActive(true);
                interfaces[0].SetActive(false);
                interfaces[1].SetActive(false);
                break;
            default:
                break;
        }
    }

    void ToggleInfo(bool isInfoOn)
    {
        infoScreen.gameObject.SetActive(isInfoOn);
        nihLogoScreen.GetComponent<Image>().enabled = !isInfoOn;
        nihLogoWindow.GetComponent<Image>().enabled = isInfoOn;
    }
}
