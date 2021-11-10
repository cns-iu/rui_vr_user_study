using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDisplayManager : MonoBehaviour
{
    public Text firstName;
    public Text lastName;
    public Text currentDate;
    public Text alignmentID;
    public Text referenceOrganID;
    public Text sectionPosition;
    public Text sectionRotation;
    public Text sectionSize;
    public DataHandlerScript dh;

    // Start is called before the first frame update
    void Start()
    {
        GlobalStateManager.SceneButtonClick += DisplayData;
    }

    void DisplayData(AppState a, int i = 0) {
        //firstName.text = dh.pd.alignment_operator_first_name;
        //lastName.text = dh.pd.alignment_operator_last_name;
        currentDate.text = dh.pd.alignment_datetime;
        alignmentID.text = dh.pd.alignment_id;
        //referenceOrganID.text = dh.pd.reference_organ_id;
        sectionPosition.text = FormatData("position");
        sectionRotation.text = FormatData("rotation");
        sectionSize.text = FormatData("size");
        //Debug.Log(dh.pd.tissue_position_mass_point.x);
    }

    string FormatData(string dimension) {
        switch (dimension)
        {
            case "position":
                Vector3 pos = dh.pd.tissue_position_mass_point;
                return pos.x + ", " + pos.y + ", " + pos.z;
            case "rotation":
                Vector3 rot = dh.pd.tissue_object_rotation;
                return rot.x + ", " + rot.y + ", " + rot.z;
            case "size":
                Vector3 size = dh.pd.tissue_object_size;
                return size.x + ", " + size.y + ", " + size.z;
            default:
                return "";
        }
    }
}
