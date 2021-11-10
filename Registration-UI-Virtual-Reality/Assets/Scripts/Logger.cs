using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    public string testerName;
    public float logInterval = 1f;
    bool isRunning = false;
    float elapsedTime;
    string taskStatus;
    GameObject[] trackers = new GameObject[3];
    GameObject headset;
    GameObject leftController;
    GameObject rightController;
    GameObject sliver;
    GameObject target;
    float distance;

    private void Start()
    {

        trackers[0] = GameObject.Find("Camera");
        trackers[1] = GameObject.Find("Controller (left)");
        trackers[2] = GameObject.Find("Controller (right)");
        sliver = GameObject.Find("Sliver");
        target = GameObject.Find("Target");
        SetupCSV();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        taskStatus = GameObject.Find("TaskStatusText").GetComponent<Text>().text;
        distance = Vector3.Distance(sliver.transform.position, target.transform.position);
        //positions[0] = 
        Debug.Log("headset at: " + trackers[0].transform.position);
        Debug.Log("distance: " + distance);

        if (!isRunning) StartCoroutine("LogMessage");
    }

    public IEnumerator LogMessage()
    {
        AddRecord(GetPath());
        isRunning = true;
        yield return new WaitForSeconds(logInterval);
        isRunning = false;
    }

    public void SetupCSV()
    {
        using (StreamWriter file = new StreamWriter(GetPath(), true))
        {
            file.WriteLine(
                "name" + ","
                + "elapsedTime" + ","
                + "taskStatus" + ","
                + "headset x" + ","
                + "headset y" + ","
                + "headset z" + ","
                + "Controller (left) x" + "," + "Controller (left) y" + "," + "Controller (left) z" + ","
                + "Controller (right) x" + "," + "Controller (right) y" + "," + "Controller (right) z" + ","
                + "distance");
        }
    }

    public void AddRecord(string filepath)
    {
        using (StreamWriter file = new StreamWriter(filepath, true))
        {
            file.WriteLine(testerName + "," + elapsedTime + "," + taskStatus + ","
                + trackers[0].transform.position.x + "," + trackers[0].transform.position.y + "," + trackers[0].transform.position.z + ","
                + trackers[1].transform.position.x + "," + trackers[1].transform.position.y + "," + trackers[1].transform.position.z + ","
                + trackers[2].transform.position.x + "," + trackers[2].transform.position.y + "," + trackers[2].transform.position.z + ","
                + distance);
        }
    }

    private string GetPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/Data/CNSData.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }
}
