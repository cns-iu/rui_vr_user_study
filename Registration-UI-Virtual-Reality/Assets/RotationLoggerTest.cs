using System.Collections;
using System.IO;
using UnityEngine;

public class RotationLoggerTest : MonoBehaviour
{
    public enum Condition { two, standup, tabletop, testing };
    //data
    public Condition cond;
    public string userName;
    int taskNumber;
    PromptType f;
    float elapsedTime;
    public GameObject headset;
    public GameObject controllerLeft;
    public GameObject controllerRight;
    string headsetPos;
    string controllerLeftPos;
    string controllerRightPos;
    float distance;
    int taskID;
    string objectName;
    GameObject currentSliver;
    GameObject currentTarget;
    string button = "";
    string side = "";
    string status = "";
    //string grabLeftStatus;
    //string menuLeftStatus;
    //string touchpadLeftStatus;
    float angle;



    string dateTimeAtStart;

    public float logInterval = 1f;
    public TaskManager tm;


    //logic
    bool isRunning = false;
    public bool isDataLogOn = false;


    private void Start()
    {
        dateTimeAtStart = GiveDateTime();
        //Debug.Log(dateTimeAtStart);

        if (isDataLogOn)
        {
            SetupCSV();
        }

    }


    void Update()
    {
        UpdateData();

        if (isDataLogOn)
        {
            if (!isRunning) StartCoroutine(LogMessage());
        }
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    StartCoroutine(LogMessage(KeyCode.A.ToString()));
        //}


    }

    public void UpdateData()
    {

        elapsedTime += Time.deltaTime;
        angle = Quaternion.Angle(transform.rotation, GetComponent<AngleExample>().sliver.transform.rotation);

        //distance = Vector3.Distance(
        //    currentSliver.transform.position,
        //    currentTarget.transform.position
        //    );

        //objectName = currentSliver.name;

    }

    public IEnumerator LogMessage()
    {
        AddRecord(GetPath());
        isRunning = true;
        yield return new WaitForSeconds(logInterval);
        isRunning = false;
    }

    public void ControllerInputListener(string btn, string si, string stat)
    {
        button = btn;
        side = si;
        status = stat;
        //Debug.Log("received " + btn + " and " + si + " and " + stat);

        //Add a record
        AddRecord(GetPath());
        ResetButtonData();
    }

    void ResetButtonData()
    {
        button = "";
        side = "";
        status = "";
    }

    public void AddRecord(string filepath)
    {
        using (StreamWriter file = new StreamWriter(filepath, true))
        {
            file.WriteLine(
           FormatMessage()
            );
        }
    }

    string FormatMessage()
    {
        Quaternion rotTarget = transform.rotation;
        //Quaternion rotSliver = GetComponent<AngleExample>().sliver.transform.rotation;
        //Debug.Log("target: " + rotTarget.eulerAngles);
        //Debug.Log("sliver: " + rotSliver.eulerAngles);

        return userName + ","

                + elapsedTime + ","
               + rotTarget.eulerAngles.x + ","
               + rotTarget.eulerAngles.y + ","
               + rotTarget.eulerAngles.z + ","
               + angle

        ;
    }

    //private void OnEnable()
    //{
    //    ControllerGrabObject.ControllerUseEvent += ControllerInputListener;
    //    ControllerControlUI.ControllerUseEvent += ControllerInputListener;
    //    ControllerResetSliver.ControllerUseEvent += ControllerInputListener;
    //    HandleSubmission.ControllerUseEvent += ControllerInputListener;
    //}

    //private void OnDisable()
    //{
    //    ControllerGrabObject.ControllerUseEvent -= ControllerInputListener;
    //    ControllerControlUI.ControllerUseEvent -= ControllerInputListener;
    //    ControllerResetSliver.ControllerUseEvent -= ControllerInputListener;
    //    HandleSubmission.ControllerUseEvent -= ControllerInputListener;
    //}

    public void SetupCSV()
    {
        using (StreamWriter file = new StreamWriter(GetPath(), true))

        {
            file.WriteLine(
                "userName" + ","

                + "elapsedTime" + ","

             
                + "targetRotationX" + ","
                + "targetRotationY" + ","
                + "targetRotationZ" + ","
                + "Quaternion.Angle"

                //+ "grab_right_status" + ","
                //+ "menu_right_status" + ","
                //+ "touchpad_right_status" + ","
                //+ "grab_left_status" + ","
                //+ "menu_left_status" + ","
                //+ "touchpad_left_status" + ","
                );
        }
    }

    private string GetPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/RUI_VR/" + cond + "/" + userName + " " + dateTimeAtStart + ".csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }

    string GiveDateTime()
    {
        dateTimeAtStart = System.DateTime.Now.ToString();
        dateTimeAtStart = dateTimeAtStart.Replace(':', '_');
        dateTimeAtStart = dateTimeAtStart.Replace('/', '.');
        return dateTimeAtStart;
    }
}
