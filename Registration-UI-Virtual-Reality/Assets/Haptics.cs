using UnityEngine;
using Valve.VR;


public class Haptics : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;
    public float duration;
    public float frequency;
    public float amplitude;
    public TaskManager tm;

    private void OnEnable()
    {
        HandleSubmission.interactEvent += Pulse;
    }

    private void OnDisable()
    {
        HandleSubmission.interactEvent -= Pulse;
    }

    void Pulse()
    {
        if (tm.isInFullResearchMode)
        {
            hapticAction.Execute(0, duration, frequency, amplitude, SteamVR_Input_Sources.RightHand);
        }

    }

}
