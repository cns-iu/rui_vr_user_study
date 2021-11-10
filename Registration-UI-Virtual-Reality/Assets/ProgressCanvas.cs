using UnityEngine;
using UnityEngine.UI;

public class ProgressCanvas : MonoBehaviour
{
    public Text progressText;
    public Text focusText;
    public Slider progressSlider;
    public TaskManager tm;

    private void Start()
    {
        progressSlider.maxValue = tm.totalAmountOfTasks;
    }

    // Update is called once per frame
    void Update()
    {
        progressText.text = tm.taskNumber + "/" + tm.totalAmountOfTasks + " tasks done";
        progressSlider.value = tm.taskNumber;
        if (tm.prompt != PromptType.SpeedShort && tm.prompt != PromptType.AccuracyShort)
        {
            focusText.text = "Focus currently on: \n" + tm.prompt.ToString();
        }
        else
        {
            if (tm.prompt == PromptType.SpeedShort)
            {
                focusText.text = "Focus currently on: \n" + PromptType.Speed.ToString();
            }
            else
            {
                focusText.text = "Focus currently on: \n" + PromptType.Accuracy.ToString();
            }
        }
    }
}
