using UnityEngine;
using UnityEngine.UI;

public class SetSizeFromUIInput : MonoBehaviour
{
    public InputField x;
    public InputField y;
    public InputField z;
    public GameObject sliver;
    public GameObject errorMessage;

    public Button btn;

    float[] standardSize = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        SetStandardSizeFromEditor();

        btn.onClick.AddListener(delegate
        {
            ResetSize();
        });

        SetInputFieldText();

        x.onEndEdit.AddListener(delegate
        {
            OnSubmitUpdate(x.text, x);
        });
        y.onEndEdit.AddListener(delegate
        {
            OnSubmitUpdate(y.text, y);
        });
        z.onEndEdit.AddListener(delegate
        {
            OnSubmitUpdate(z.text, z);
        });
    }

    void OnSubmitUpdate(string text, InputField i)
    {
        try
        {
            sliver.transform.localScale = new Vector3(
             (float.Parse(x.text) / 20f),
             (float.Parse(y.text) / 20f),
             (float.Parse(z.text) / 20f)
             );
            errorMessage.gameObject.SetActive(false);
        }
        catch (System.FormatException e)
        {
            errorMessage.gameObject.SetActive(true);
            Debug.Log(e);
            if (i == x)
            {
                i.text = (standardSize[0]* 20f).ToString();
                
            }
            else if (i == y)
            {
                i.text = (standardSize[1]* 20f).ToString();
            }
            else
            {
                i.text = (standardSize[2]* 20f).ToString();
            }
            i.GetComponent<Image>().sprite = i.GetComponent<InputFieldStateHandler>().error;
        }
    }

    void ResetSize()
    {
        sliver.transform.localScale = new Vector3(
             standardSize[0],
             standardSize[1],
             standardSize[2]
             );
        SetInputFieldText();
    }

    void SetStandardSizeFromEditor()
    {
        standardSize[0] = sliver.transform.localScale.x;
        standardSize[1] = sliver.transform.localScale.y;
        standardSize[2] = sliver.transform.localScale.z;
        SetInputFieldText();
    }

    void SetInputFieldText()
    {
        x.text = (sliver.transform.localScale.x * 20f).ToString();
        y.text = (sliver.transform.localScale.y * 20f).ToString();
        z.text = (sliver.transform.localScale.z * 20f).ToString();
    }
}
