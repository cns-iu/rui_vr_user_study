using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetrieveOntologyOnCollision : MonoBehaviour
{

    public List<GameObject> collidedObjects;
    public List<Text> collisionTextDisplayLine;

    private void OnTriggerEnter(Collider other)
    {
        //string name = other.transform.parent.name;
        collidedObjects.Add(other.gameObject.transform.parent.gameObject);
        UpdateDisplayText();
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("leaving");
        collidedObjects.Remove(other.gameObject.transform.parent.gameObject);
        UpdateDisplayText();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        for (int i = 0; i < collidedObjects.Count; i++)
    //        {
    //            Debug.Log(collidedObjects[i].ToString());
    //        }

    //    }
    //}

    void UpdateDisplayText()
    {
        //Debug.Log("collidedObjects.Count = " + collidedObjects.Count);
        
        for (int i = 0; i < collidedObjects.Count; i++)
        {
            //Debug.Log(i);
            //Debug.Log(collidedObjects[i].name);
            collisionTextDisplayLine[i].text = collidedObjects[i].name;
        }
        int tempI = collidedObjects.Count;
        for (int j = tempI; j < (collisionTextDisplayLine.Count - tempI); j++)
        {
            collisionTextDisplayLine[j].text = "";
        }

        //if collidedObjects.Count = 0
        //collisionTextDisplayLine[0].text = "";
        //collisionTextDisplayLine[1].text = "";
        //collisionTextDisplayLine[2].text = "";
        //collisionTextDisplayLine[3].text = "";
        //collisionTextDisplayLine[4].text = "";
        //collisionTextDisplayLine[5].text = "";

        //if collidedObjects.Count = 1
        //collisionTextDisplayLine[0].text = collidedObjects[0].name;
        //collisionTextDisplayLine[1].text = "";
        //collisionTextDisplayLine[2].text = "";
        //collisionTextDisplayLine[3].text = "";
        //collisionTextDisplayLine[4].text = "";
        //collisionTextDisplayLine[5].text = "";

        //if collidedObjects.Count = 2
        //collisionTextDisplayLine[0].text = collidedObjects[0].name;
        //collisionTextDisplayLine[1].text = collidedObjects[1].name;
        //collisionTextDisplayLine[2].text = "";
        //collisionTextDisplayLine[3].text = "";
        //collisionTextDisplayLine[4].text = "";
        //collisionTextDisplayLine[5].text = "";

        //for (int j = 0; j < length; j++)
        //{

        //}
    }
}
