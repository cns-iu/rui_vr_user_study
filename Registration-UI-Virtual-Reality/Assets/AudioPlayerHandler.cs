using UnityEngine;

public class AudioPlayerHandler : MonoBehaviour
{
    public AudioSource[] audioSources = new AudioSource[4];
    public TaskManager tm;

    private void OnEnable()
    {
        TaskManager.AudioPlayEvent += Play;
    }

    private void OnDisable()
    {
        TaskManager.AudioPlayEvent -= Play;
    }

    void Play(PromptType f)
    {
        if (tm.isInFullResearchMode)
        {
            audioSources[(int)f].Play();
        }
    }
}
