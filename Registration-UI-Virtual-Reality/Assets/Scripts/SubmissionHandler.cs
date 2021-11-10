using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SubmissionHandler : MonoBehaviour
{
    public DataHandler dh;
    public GameObject table;
    public GameObject firstRow;
    public GameObject pre_Row;
    public Canvas ca;
    public float offset;

    public Button submit;

    string[] fields;
    // Start is called before the first frame update
    void Start()
    {
        submit.onClick.AddListener(delegate {
            File.WriteAllText(Application.dataPath + "/Data/JSONExport.json", JsonUtility.ToJson(dh.pd));
            Debug.Log("file saved");
        });

        fields = new string[16] {
            "userName",
            "organName",
            "Operator_ORCID",
            "Sample_acquired_date_time",
            "Sectioning_date_time",
            "Sample_site",
            "Patient_visit",
            "Sample_id",
            "Sample_organ",
            "Sample_organ_laterality",
            "Organ_object_file_name",
            "Organ_object_size",
            "Section_object_position",
            "Section_object_rotation",
            "Section_object_size",
            "Current_date"
        };

       

        dh = GameObject.Find("DataManager").GetComponent<DataHandler>();
        //Debug.Log(dh.pd.userName);
        table = GameObject.Find("Table");
        //Debug.Log(dh.pd.GetType().GetProperties().ToString());
        for (int i = 0; i < fields.Length; i++)
        {
            CreateRow(i, fields[i]);
        }
        table.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>().text = dh.pd.userName;
        table.transform.GetChild(2).transform.GetChild(1).GetComponent<Text>().text = dh.pd.organName;
        table.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Operator_ORCID;
        table.transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Sample_acquired_date_time;
        table.transform.GetChild(5).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Sectioning_date_time;
        table.transform.GetChild(6).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Sample_site;
        table.transform.GetChild(7).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Patient_visit;
        table.transform.GetChild(8).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Sample_id;
        table.transform.GetChild(9).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Sample_organ;
        table.transform.GetChild(10).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Sample_organ_laterality;
        table.transform.GetChild(11).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Organ_object_file_name;
        table.transform.GetChild(12).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Organ_object_size.ToString();
        table.transform.GetChild(13).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Section_object_position.ToString();
        table.transform.GetChild(14).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Section_object_rotation.ToString();
        table.transform.GetChild(15).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Section_object_size.ToString();
        table.transform.GetChild(16).transform.GetChild(1).GetComponent<Text>().text = dh.pd.Current_date.ToString();
        Debug.Log(dh.pd.Section_object_position);

        
        //dh.SaveData(DataHandler.OutputFormat.json);
    }

    void CreateRow(int i, string s) {
        GameObject row = Instantiate(pre_Row);
        row.transform.parent = table.transform;
        row.transform.position = new Vector3(firstRow.transform.position.x, firstRow.transform.position.y - offset * i, firstRow.transform.position.z);
        row.transform.GetChild(0).GetComponent<Text>().text = s;
    }

    
    
    
}
