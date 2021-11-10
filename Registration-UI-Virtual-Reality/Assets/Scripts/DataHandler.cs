using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour
{
    public Button nextScene;

    private void OnEnable()
    {
        nextScene.onClick.AddListener(delegate
        {
            UpdateData();
        });
    }

    private void OnDisable()
    {
        
    }
    public enum OutputFormat { json, csv };

    public GameObject sliver;
    public CoordinateSystemControl co;
    public Button load;
    public Button saveJson;
    public Button copyJson;
    public Button saveCsv;
    public Button copyCsv;
    public Text textSceneInfo;
    PlayerData loadedData;

    public PlayerData pd = new PlayerData();

    // Start is called before the first frame update
    private void Awake()
    {
        GenerateData();
        //Debug.Log(BoardingData.ToString());
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        saveJson.onClick.AddListener(
            delegate
            {
                SaveData(OutputFormat.json);
            }
            );

        copyJson.onClick.AddListener(
            delegate
        {
            CopyData(OutputFormat.json);
        });

        saveCsv.onClick.AddListener(
            delegate
            {
                SaveData(OutputFormat.csv);
            });

        copyCsv.onClick.AddListener(
            delegate
            {
                CopyData(OutputFormat.csv);
            });

        load.onClick.AddListener(
           delegate
           {
               LoadDataFromJson();
           });

        SetSceneOverviewUI();
    }


    public void SaveData(OutputFormat of)
    {
        switch (of)
        {
            case OutputFormat.json:
                File.WriteAllText(GetPath(of), FormatData(of));
                break;
        }
        Debug.Log("Saved as " + of + " to " + GetPath(of));
    }

    void CopyData(OutputFormat of)
    {
        TextEditor te = new TextEditor
        {
            text = FormatData(of)
        };
        te.SelectAll();
        te.Copy();
        Debug.Log("Copied as " + of + " to " + GetPath(of));
    }

    string FormatData(OutputFormat of, string var = "")
    {
        UpdateData();
        switch (of)
        {
            case OutputFormat.json:
                string json = JsonUtility.ToJson(pd);
                return json;
            case OutputFormat.csv:
                return "";
            default:
                return "Internal error; no correct output format chosen.";
        }
    }

    string GetPath(OutputFormat of)
    {
        return Application.dataPath + "/Data/saveFile." + of;
    }

    public class PlayerData
    {
        //FROM CHECK-IN
        public string userName;
        public string organName;

        //OPERATOR
        public string Operator_ORCID;
        public string Sample_acquired_date_time;
        public string Sectioning_date_time;
        public string Sample_site;

        //SAMPLE
        public string Patient_visit;
        public string Sample_id;
        public string Sample_organ;
        public string Sample_organ_laterality;

        //REGISTRATION
        public string Organ_object_file_name;
        public Vector3 Organ_object_size;
        public Vector3 Section_object_position;
        public Vector3 Section_object_rotation;
        public Vector3 Section_object_size;
        public string Current_date;
    }

    void GenerateData()
    {
        //pd.userName = BoardingData.user;
        //pd.organName = BoardingData.organ;

        pd.Operator_ORCID = "1234567890";
        pd.Sample_acquired_date_time = "SomeDateTime1";
        pd.Sectioning_date_time = "SomeDateTime2";
        pd.Sample_site = "TMC_Vanderbilt";

        pd.Patient_visit = "SomePatientId";
        pd.Sample_id = "SomeSampleId";
        pd.Sample_organ = "kidney";
        pd.Sample_organ_laterality = "left";

        pd.Organ_object_file_name = "";
        pd.Organ_object_size = new Vector3(6f, 10f, 4f);
        pd.Section_object_position = co.normalizedPosition;
        pd.Section_object_rotation = sliver.transform.eulerAngles;
        pd.Section_object_size = sliver.transform.localScale * 2f;
        pd.Current_date = System.DateTime.Now.ToString();
    }

    void LoadDataFromJson()
    {
        // Read the json from the file into a string
        string dataAsJson = File.ReadAllText(Application.dataPath + "/Data/saveFile.json");
        Debug.Log("Loaded:/n" + dataAsJson);
        // Pass the json to JsonUtility, and tell it to create a GameData object from it
        loadedData = JsonUtility.FromJson<PlayerData>(dataAsJson);
        UpdateSceneFromLoadedData();
        //Debug.Log(loadedPlayerData.position + ", " +  loadedPlayerData.health);
    }

    void UpdateData()
    {
        pd.Section_object_position = co.normalizedPosition;
        pd.Section_object_rotation = sliver.transform.eulerAngles;
        pd.Section_object_size = sliver.transform.localScale * 2f;
        pd.Current_date = System.DateTime.Now.ToString();
        Debug.Log("Data updated");
    }

    void UpdateSceneFromLoadedData()
    {
        //sliver.transform.position = loadedData.sliverPosition;
        //sliver.transform.rotation = Quaternion.Euler(loadedData.sliverRotation);
    }

    void SetSceneOverviewUI()
    {
        textSceneInfo.text = "Organ: " + pd.Sample_organ + "\n"
            + "Lateriality: " + pd.Sample_organ_laterality + "\n"
            + "Organ version: " + pd.Organ_object_file_name;
    }
}
