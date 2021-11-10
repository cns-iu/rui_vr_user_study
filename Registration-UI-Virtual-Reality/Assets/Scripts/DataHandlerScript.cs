using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Collections;

public class DataHandlerScript : MonoBehaviour
{

    public PlayerData pd = new PlayerData();
    public InputField firstName;
    public InputField lastName;
    public GameObject sliver;
    public bool NeedVertices = false;
    public CoordinateSystemControl co;
    public Button copyButton;
    public Button registerNewButton;
    public Image registerNewButtonImage;
    public GameObject copyMessage;
    public float messageDuration;

    public Slider[] sliders = new Slider[3];

    private IEnumerator coroutine;
    float counter;

    Mesh m;
    Vector3[] verticesRaw;
    
    [DllImport("__Internal")]
    private static extern void CopyToClipboard(string s);

    private void Start()
    {
        copyButton.onClick.AddListener(
            delegate {
                coroutine = ShowTimedPopUpMessage(messageDuration);
                //Debug.Log("lets do it");
                //StartCoroutine(coroutine);
                TurnButtonOnOff(true);
                //Debug.Log(registerNewButtonImage.enabled);
                CopyData();
                
                //registerNewButton.interactable = true;
            });

        registerNewButton.onClick.AddListener(
            delegate {
                GetGUID();
                TurnButtonOnOff(false);
            });
    }

    IEnumerator ShowTimedPopUpMessage(float t) {
        copyMessage.SetActive(true);
        yield return new WaitForSeconds(t);
        copyMessage.SetActive(false);
    }

    public void TurnButtonOnOff(bool turn) {
        registerNewButton.interactable = turn;
        registerNewButtonImage.enabled = turn;
    }
    
    private void Awake()
    {
        GenerateData();
        //Debug.Log(pd.ToString());
    }

    private void GetGUID() {
        pd.alignment_id = Guid.NewGuid().ToString();
    }

    void GenerateData()
    {
        GetGUID();
        //pd.reference_organ_id = "uuid-1234-5678";
    }

    public void UpdateData()
    {
        //pd.alignment_operator_first_name = SetUserName("first");
        //pd.alignment_operator_last_name = SetUserName("last");
        pd.alignment_datetime = System.DateTime.Now.ToString();
        //pd.tissue_position_vertices = sliver.GetComponent<ExtractVertices>().GetVertices();
        if (NeedVertices)
        {
            //pd.tissue_position_vertices = GetVertices();
        }
        else
        {
            //Debug.Log("coning now");
            //Debug.Log(pd.tissue_position_mass_point.y);
            //Anti-clockwise angle = 360 degrees - clockwise angle
            pd.tissue_position_mass_point = co.normalizedPosition;
            pd.tissue_object_rotation = new Vector3(
                RoundToNDecimals(sliver.transform.eulerAngles.x),
                RoundToNDecimals(sliver.transform.eulerAngles.y),
                RoundToNDecimals(sliver.transform.eulerAngles.z)
                );
            pd.tissue_object_size = new Vector3(
                RoundToNDecimals(sliver.transform.localScale.x * 20f),
                RoundToNDecimals(sliver.transform.localScale.y * 20f),
                RoundToNDecimals(sliver.transform.localScale.z * 20f)
                );
            //Debug.Log(pd.tissue_position_mass_point.y);
        }

        //Debug.Log(pd.alignment_operator_name);
    }

    float RoundToNDecimals(float x)
    {
        return Mathf.Round(x * 100f) / 100f;
    }

    public void CopyData()
    {
        UpdateData();
        string s = JsonUtility.ToJson(pd, true);
        //Debug.Log(s);
        CopyToClipboard(s);
        //Debug.Log("Copied to clipboard");
    }


    public class PlayerData
    {
        public string alignment_id;
        //public string alignment_operator_first_name;
        //public string alignment_operator_last_name;
        public string alignment_datetime;
        //public string reference_organ_id;
        //public Vector3[] tissue_position_vertices;
        public Vector3 tissue_position_mass_point;
        public Vector3 tissue_object_rotation;
        public Vector3 tissue_object_size;

        public override string ToString()
        {
            return "This is user data.";
        }
    }

    Vector3[] GetVertices()
    {

        m = sliver.GetComponent<MeshFilter>().mesh;
        verticesRaw = m.vertices;
        for (int i = 0; i < verticesRaw.Length; i++)
        {
            Debug.Log(verticesRaw[i]);
            //Vector3 worldPt = transform.TransformPoint(verticesRaw[i]);
            //Debug.Log(worldPt);
        }
        return verticesRaw;
    }

    string SetUserName(string which)
    {
        switch (which)
        {
            case "first":
                return firstName.text;
            case "last":
                return lastName.text;
            default:
                return "";
                break;
        }
        
    }
}
