using System.Collections;
using UnityEngine;

public enum PromptType { Tutorial, Speed, Accuracy, Sequence, AccuracyShort, SpeedShort };
public enum ExperimentState { Tutorial, Complexity, Plateau }


public class TaskManager : MonoBehaviour
{
    public PromptType prompt = PromptType.Tutorial;
    public ExperimentState state = ExperimentState.Tutorial;

    public Transform sliverStartPos;
    public Transform targetStartPos;
    public int taskNumber;
    public GameObject currentSliver;
    public GameObject currentTarget;
    public int taskID;

    public string start = "Start sequence: ";
    public string output = "Random sequence: ";

    public Transform finalRotation1;
    public float totalAmountOfTasks = 23f;

    public Transform pre_Sliver;
    public Transform pre_Target;

    public DistanceTool dt;
    public Transform kidney;

    public float lastComplexityTask = 14f;

    public GameObject[] slivers;
    public GameObject[] targets;
    int[] tasksStartSequence;
    int[] tasksFinalSequence;

    float startDistance;
    float endDistance;
    float startScale;
    float endScale;



    //public float rescaleFactor;

    public delegate void BeginningOfSession();
    public static event BeginningOfSession BeginningOfSessionEvent;

    public delegate void TaskUpdate();
    public static event TaskUpdate TaskUpdateEvent;

    public delegate void EndOfSession();
    public static event EndOfSession EndOfSessionEvent;

    public delegate void Audio(PromptType f);
    public static event Audio AudioPlayEvent;

    bool showWarning = false;
    public bool isInFullResearchMode = true;


    [SerializeField]
    bool showSliversAndTargets = false;
    [SerializeField]
    bool randomizeTaskOrder = true;

    private void OnEnable()
    {
        HandleSubmission.interactEvent += NextTask;
        HandleSubmissionDesktop.interactEvent += NextTask;
    }

    private void OnDisable()
    {
        HandleSubmission.interactEvent += NextTask;

    }

    void Awake()
    {
        slivers = new GameObject[(int)totalAmountOfTasks];
        targets = new GameObject[(int)totalAmountOfTasks];
        tasksStartSequence = new int[(int)totalAmountOfTasks];
        tasksFinalSequence = new int[(int)totalAmountOfTasks];

        for (int i = 0; i < slivers.Length; i++)
        {
            slivers[i] = Instantiate(pre_Sliver.gameObject);
        }
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = Instantiate(pre_Target.gameObject);
        }

        startDistance = .3f * dt.distance;
        endDistance = 2f * dt.distance;
        startScale = .2f * dt.distance;
        endScale = .05f * dt.distance;
        //Debug.Log(dt.distance);
        UpdateVariables();
        SetSliverAndTargetState(true);
        SetSliverAndTargetStartPos();
        SetSizes();
        SetTargetRotation();
        GenerateRandomSequence();

    }

    private void Start()
    {
        if (BeginningOfSessionEvent != null)
        {

            BeginningOfSessionEvent();
        }
        StartCoroutine(PlayAudioAfterDelay());
    }

    IEnumerator PlayAudioAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        if (AudioPlayEvent != null)
        {
            AudioPlayEvent(PromptType.Tutorial);
        }
    }

    private void LogRotationToConsole()
    {
        UnityEditor.TransformUtils.SetInspectorRotation(currentTarget.transform, new Vector3(45, 0, 133));

        Debug.Log("UnityEditor.TransformUtils.GetInspectorRotation(currentTarget.transform).x/y/z: "
            + UnityEditor.TransformUtils.GetInspectorRotation(currentTarget.transform).x
            + "," + UnityEditor.TransformUtils.GetInspectorRotation(currentTarget.transform).y + ","
            + UnityEditor.TransformUtils.GetInspectorRotation(currentTarget.transform).z);
        Debug.Log("currentTarget.transform.localEulerAngles: " + currentTarget.transform.localEulerAngles);
    }

    void GenerateRandomSequence()
    {
        int num = 0;
        for (int i = 0; i < tasksStartSequence.Length; i++)
        {
            tasksStartSequence[i] = num;
            num++;
        }

        for (int i = 0; i < tasksStartSequence.Length; i++)
        {
            start += tasksStartSequence[i] + " ";
        }
        //Debug.Log(start);
        tasksFinalSequence = tasksStartSequence;

        if (randomizeTaskOrder)
        {
            int tempNum;
            for (int i = 1; i < tasksFinalSequence.Length; i++)
            {
                int rnd = Random.Range(1, tasksFinalSequence.Length);
                tempNum = tasksFinalSequence[rnd];
                tasksFinalSequence[rnd] = tasksFinalSequence[i];
                tasksFinalSequence[i] = tempNum;
            }


            //Debug.Log(output);
        }
        for (int i = 0; i < tasksFinalSequence.Length; i++)
        {
            output += tasksFinalSequence[i] + " ";
        }

    }

    void NextTask()
    {
        SetSliverAndTargetState(false);
        //add new code for plateau phase
        if (taskNumber < (totalAmountOfTasks - 1))
        {
            taskNumber++;
            UpdateVariables();
            SetSliverAndTargetState(true);
            SetSliverAndTargetStartPos();
            SetSizes();
            SetTargetRotation();
            if (TaskUpdateEvent != null) TaskUpdateEvent();
        }
        else
        {
            if (EndOfSessionEvent != null) EndOfSessionEvent();
        }
    }

    void UpdateVariables()
    {
        currentSliver = slivers[tasksFinalSequence[taskNumber]];
        currentTarget = targets[tasksFinalSequence[taskNumber]];
        taskID = tasksFinalSequence[taskNumber];
        //set slivers at medium distance, medium size (both fixed), and medium rotation

        if (taskID == 0)
        {
            prompt = PromptType.Tutorial;
            state = ExperimentState.Tutorial;
        }

        else if (taskID > 0 && taskID <= lastComplexityTask)
        {
            state = ExperimentState.Complexity;
            if (taskID % 2 != 0)
            {
                if (taskID == 1)
                {
                    prompt = PromptType.Speed;
                }
                else
                {
                    prompt = PromptType.SpeedShort;
                }

            }
            else
            {
                if (taskID == 2)
                {
                    prompt = PromptType.Accuracy;
                }
                else
                {
                    prompt = PromptType.AccuracyShort;
                }

            }

            if (AudioPlayEvent != null)
            {
                AudioPlayEvent(prompt);
            }
        }
        else if (taskID == (lastComplexityTask + 1))
        {
            state = ExperimentState.Plateau;
            prompt = PromptType.Sequence;
            if (AudioPlayEvent != null)
            {
                AudioPlayEvent(prompt);
            }

        }

        //set slivers at medium distance, medium size (both fixed), and medium rotation


    }

    void SetSliverAndTargetState(bool isActive)
    {
        currentSliver.SetActive(isActive);
        currentTarget.SetActive(isActive);
    }

    void SetSliverToStartPos()
    {
        currentSliver.transform.position = sliverStartPos.position;
    }

    void SetSliverAndTargetStartPos()
    {
        currentTarget.transform.position = targetStartPos.position;
        //Debug.Log("current sliver positioned");
        UpdateSliverStartPos();
        currentSliver.transform.position = sliverStartPos.transform.position;
        //currentTarget.transform.position = sliverStartPos.transform.position;
    }

    void UpdateSliverStartPos()
    {
        if (state == ExperimentState.Tutorial)
        {
            sliverStartPos.position = new Vector3(
            kidney.transform.position.x,
            kidney.transform.position.y,
            kidney.transform.position.z - startDistance
            );
        }
        else if (state == ExperimentState.Complexity)
        {
            float t = taskID / lastComplexityTask;
            float offset = Mathf.Lerp(startDistance, endDistance, t);
            //Debug.Log(Vector3.Distance(kidney.position, sliverStartPos.position) + ", " + dt.distance * 2 + ", " + t);
            sliverStartPos.transform.position = new Vector3(
                kidney.position.x,
                kidney.position.y,
                kidney.position.z - offset
                );
            //Debug.Log(sliverStartPos.position.z);
        }
        else
        {

            sliverStartPos.position = new Vector3(
            kidney.transform.position.x,
            kidney.transform.position.y,
            kidney.transform.position.z - ((endDistance + startDistance) / 2f));
            //Debug.Log("end: "+ endDistance);
            //Debug.Log("start: " + startDistance);
            //Debug.Log((endDistance + startDistance) / 2f);
            //Debug.Log(sliverStartPos.position.z);



        }

        //Debug.Log(sliverStartOffset);
    }

    void SetSizes()
    {

        Vector3 rescaleVector = new Vector3(
        startScale,
        startScale,
        startScale
        );


        if (state == ExperimentState.Complexity)
        {
            float t = taskID / lastComplexityTask;
            rescaleVector = Vector3.Lerp(new Vector3(startScale, startScale, startScale), new Vector3(endScale, endScale, endScale), t);
        }
        else if (state == ExperimentState.Plateau)

        {
            rescaleVector = new Vector3(
                (startScale + endScale) / 2f,
                (startScale + endScale) / 2f,
                (startScale + endScale) / 2f
                );
        }

        currentSliver.transform.localScale = rescaleVector;
        currentTarget.transform.localScale = rescaleVector;
    }

    void SetTargetRotation()
    {
        float t = taskID / lastComplexityTask;
        currentTarget.transform.rotation = Quaternion.Slerp(sliverStartPos.transform.rotation, finalRotation1.rotation, t);

    }

    private void OnDrawGizmos()
    {
        if (showSliversAndTargets)
        {
            for (int i = 0; i < slivers.Length; i++)
            {
                Gizmos.DrawLine(slivers[i].transform.position, targets[i].transform.position);
                //Debug.Log("GIZMO DRAW");
            }
        }

    }

    //private void OnValidate()
    //{
    //    if (showSliversAndTargets)
    //    {
    //        foreach (var item in slivers)
    //        {
    //            item.SetActive(true);
    //        }
    //        foreach (var item in targets)
    //        {
    //            item.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        foreach (var item in slivers)
    //        {
    //            item.SetActive(false);
    //        }
    //        foreach (var item in targets)
    //        {
    //            item.SetActive(false);
    //        }
    //    }




    //}



}
