using UnityEngine;
using Valve.VR;
using System.Collections;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2

    public delegate void Grab();
    public static event Grab GrabEvent;

    public delegate void ControllerUse(string key, string hand, string status);
    public static event ControllerUse ControllerUseEvent;

    public delegate void SliverTouch();
    public static event SliverTouch SliverTouchEvent;

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        // 1
        if (grabAction.GetLastStateDown(handType))
        {
            if (ControllerUseEvent != null) ControllerUseEvent("grab", "right", "down");
            //Debug.Log("controller use event fired");
            //Debug.Log("Grabbed");
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // 2
        if (grabAction.GetLastStateUp(handType))
        {
            if (ControllerUseEvent != null) ControllerUseEvent("grab", "right", "up");
            if (objectInHand)
            {
                ReleaseObject();
            }
            //print("Released");
        }
       

    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        if (other.tag == "Sliver")
        {
            if (SliverTouchEvent != null)
            {
                SliverTouchEvent();
            }
        }
        
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("Staying");
        SetCollidingObject(other);
        
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        //if (ControllerUseEvent != null) ControllerUseEvent("grab", handType.ToString(), "down");
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        //Debug.Log("Entered");

        //Debug.Log("called at " + Time.time);
        if (GrabEvent != null) GrabEvent();

    }



    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            //objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
            objectInHand.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            objectInHand.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);

        }
        // 4
        objectInHand = null;
    }



}
