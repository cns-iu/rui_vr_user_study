using System.IO;
using UnityEngine;

public enum Condition { Standup, Tabletop, Desktop }

public class BuildTrajectory : MonoBehaviour
{
    public Condition m_Condition = Condition.Standup;
    public string m_Filename;

    //[Header("Data vars")]
    //public bool[] m_DataVarsToVisualize = new bool[10];

    public GameObject m_HeadMark;
    public Sprite head;
    public GameObject m_RHandMark;
    public GameObject m_LHandMark;
    public GameObject m_ParentObject;

    // Start is called before the first frame update
    void Awake()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        int counter = 0;

        StreamReader streamReader = new StreamReader(Application.dataPath + "/Data/RUI_VR/" + m_Condition + "/" + m_Filename + ".csv");
        bool endOfFile = false;
        string dataString = streamReader.ReadLine();
        while (!endOfFile)
        {
            dataString = streamReader.ReadLine();
            if (dataString == null)
            {
                endOfFile = true;
                break;
            }
            string[] dataValues = dataString.Split(',');
            //Debug.Log(dataValues.ToString());


            float[] elements = new float[9];
            elements[0] = float.Parse(dataValues[6]);
            elements[1] = float.Parse(dataValues[7]);
            elements[2] = float.Parse(dataValues[8]);
            elements[3] = float.Parse(dataValues[9]);
            elements[4] = float.Parse(dataValues[10]);
            elements[5] = float.Parse(dataValues[11]);
            elements[6] = float.Parse(dataValues[12]);
            elements[7] = float.Parse(dataValues[13]);
            elements[8] = float.Parse(dataValues[14]);
            //Debug.Log("Read: " + dataValues.ToString());
            Vector3 spawnPosition1 = new Vector3(
                     elements[0],
                      elements[1],
                       elements[2]
                    );

            Vector3 spawnPosition2 = new Vector3(
                     elements[3],
                      elements[4],
                       elements[5]
                    );

            Vector3 spawnPosition3 = new Vector3(
                     elements[6],
                      elements[7],
                       elements[8]
                    );
            if (counter%1==0f)
            {
                GameObject sphere = SpawnSphere(m_HeadMark, spawnPosition1);
                //Debug.Log("Spawning mark at: " );
                sphere.transform.parent = m_ParentObject.transform;

                GameObject leftSphere = SpawnSphere(m_LHandMark, spawnPosition2);

                leftSphere.transform.parent = m_ParentObject.transform;

                GameObject rightSphere = SpawnSphere(m_RHandMark, spawnPosition3);
                rightSphere.transform.parent = m_ParentObject.transform;
            }
          
            counter++;
        }
    }

    GameObject SpawnSphere(GameObject mark, Vector3 spawnPosition)
    {
        GameObject create = Instantiate(mark, spawnPosition, Quaternion.identity);
        //SpriteRenderer renderer = create.AddComponent<SpriteRenderer>();
        //renderer.sprite = head;
        //Vector3 scale = new Vector3(0.00324419f, 0.00324419f, 0.00324419f);
        //create.transform.localScale = scale;


        return (create);
    }
}
