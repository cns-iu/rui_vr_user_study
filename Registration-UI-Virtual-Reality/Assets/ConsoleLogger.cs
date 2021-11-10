using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleLogger : MonoBehaviour
{
    public DataLogger dl;
    public TaskManager tm;
    public Transform start;
    public Transform end;
    public Transform middle;
    public Transform kidney;
    // Start is called before the first frame update
    void Start()
    {
        start.position = new Vector3(
            kidney.transform.position.x,
            kidney.transform.position.y,
            kidney.transform.position.z - (.3f * 4.9601f)
            );

        end.position = new Vector3(
            kidney.transform.position.x,
            kidney.transform.position.y,
            kidney.transform.position.z - (2f * 4.9601f)
            );

       middle.position = new Vector3(
            kidney.transform.position.x,
            kidney.transform.position.y,
            kidney.transform.position.z - (((2f * 4.9601f) + (.3f * 4.9601f)) / 2f)
            );
    }

}
