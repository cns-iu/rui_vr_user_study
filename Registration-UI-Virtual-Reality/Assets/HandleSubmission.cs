using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))] //A collider is needed to receive clicks

public class HandleSubmission : MonoBehaviour
{
    public delegate void interact();
    public static event interact interactEvent;

    public delegate void ControllerUse(string key, string hand, string status);
    public static event ControllerUse ControllerUseEvent;

    public bool isBuzzerReady = true;
    public float buzzerFreezeTimeAfterSubmission;
    //public bool hasNewSliverBeenTouched = false;

    public AudioSource audioSource;

    Animator anim;

    public TaskManager tm;

    private void OnEnable()
    {
        interactEvent += BuzzerAnimation;
        TaskManager.AudioPlayEvent += ExecuteOnAudioPlay;
        ControllerGrabObject.SliverTouchEvent += CheckControllerSliverTouchStatus;
    }

    private void OnDisable()
    {
        interactEvent -= BuzzerAnimation;
        TaskManager.AudioPlayEvent -= ExecuteOnAudioPlay;
        ControllerGrabObject.SliverTouchEvent -= CheckControllerSliverTouchStatus;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        //interactEvent.AddListener(ResetButton);
        //Debug.Log(anim.GetBool("isPressed"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBuzzerReady)
        {
            //interactEvent.Invoke();
            if (other.name == "Controller (right)")
            {
                ExecuteOnInput();
            }
        }
    }

    void ExecuteOnAudioPlay(PromptType f)
    {
        if (tm.isInFullResearchMode)
        {
            StartCoroutine(FreezeBuzzer(audioSource.clip.length + 3f));
        }
    }

    void CheckControllerSliverTouchStatus()
    {
        isBuzzerReady = true;
        //if (true)
        //{

        //}
        //hasNewSliverBeenTouched = true;
    }


    void ExecuteOnInput()
    {

        if (interactEvent != null)
        {
            interactEvent();
            //Debug.Log("event called");
        }
        if (ControllerUseEvent != null)
        {
            ControllerUseEvent("buzzer", "none", "pressed");
        }
        //if (tm.isInFullResearchMode)
        //{
        //StartCoroutine(FreezeBuzzer(buzzerFreezeTimeAfterSubmission));
        isBuzzerReady = false;
        //}

        //Debug.Log(Time.time);
    }

    IEnumerator FreezeBuzzer(float t)
    {
        isBuzzerReady = false;
        //Debug.Log(Time.time);
        //Debug.Log("buzzer Frozen");
        yield return new WaitForSeconds(t);
        isBuzzerReady = true;
        //Debug.Log("buzzer good");
        //Debug.Log(isBuzzerReady);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            ExecuteOnInput();
        }


    }

    void BuzzerAnimation()
    {
        anim.SetTrigger("BuzzerPress");
    }


}
