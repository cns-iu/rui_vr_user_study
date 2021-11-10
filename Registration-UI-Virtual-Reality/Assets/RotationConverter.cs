using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class RotationConverter : MonoBehaviour
{

    Vector3 sliverRotEuler;
    Vector3 targetRotEuler;
    Quaternion sliverRotQuaternion;
    Quaternion targetRotQuaternion;
    float angle;

    public TextAsset InCsvFile;
    //public TextAsset OutCsvFile;
    private char lineSeparator = '\n'; // It defines line seperate character
    private char fieldSeparator = ','; // It defines field seperate chracter
    string output = "";

    // Start is called before the first frame update
    void Start()
    {
        //89.08764f, 193.3661f, 167.3301f
        sliverRotEuler = new Vector3(0, 0, 0);
        sliverRotQuaternion = Quaternion.Euler(sliverRotEuler);

        targetRotEuler = new Vector3(89.00025f, 101.0002f, 77.00021f);
        targetRotQuaternion = Quaternion.Euler(targetRotEuler);

        angle = Quaternion.Angle(sliverRotQuaternion, targetRotQuaternion);
        //Debug.Log(angle);
        ReadDataAndConvert();
    }

    void ReadDataAndConvert()
    {
        string userName = "";
        string[] line = InCsvFile.text.Split(lineSeparator);
        for (int i = 1; i < line.Length-1; i++)
        {
            string[] cell = line[i].Split(fieldSeparator);
            sliverRotEuler = new Vector3(
                    float.Parse(cell[18]), float.Parse(cell[19]), float.Parse(cell[20])
                );
            targetRotEuler = new Vector3(
                    float.Parse(cell[21]), float.Parse(cell[22]), float.Parse(cell[23])
                );
            

            //Debug.Log(sliverRotEuler);
            //Debug.Log(targetRotEuler);

            sliverRotQuaternion = Quaternion.Euler(sliverRotEuler);
            targetRotQuaternion = Quaternion.Euler(targetRotEuler);

            angle = Quaternion.Angle(sliverRotQuaternion, targetRotQuaternion);
            //Debug.Log(angle);
            output += angle + "\n";
            //Debug.Log(cell[18] + "," + cell[19] + "," + cell[20]);

            
        }

        userName = line[1].Split(fieldSeparator)[0];




        using (StreamWriter file = new StreamWriter("D:/BoxSyncAlex/Box Sync/18-HuBMAP-w/Registration UI/threeJS-w/Registration-UI-Virtual-Reality/Assets/Data/RUI_VR/standup/QuaternionAngles/" + userName + ".csv", false))
        {
            file.WriteLine(
                output
            );
        }
        Debug.Log("done");
    }
}

