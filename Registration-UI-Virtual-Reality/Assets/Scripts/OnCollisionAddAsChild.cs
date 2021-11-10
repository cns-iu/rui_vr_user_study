using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAddAsChild : MonoBehaviour
{
    bool isChild = false;

    private void OnEnable()
    {
        SliverCollisionEventHandler.OnSliverEnterEvent += Parent;
        SliverCollisionEventHandler.OnSliverExitEvent += Unparent;
    }

    private void OnDisable()
    {
        SliverCollisionEventHandler.OnSliverEnterEvent -= Parent;
        SliverCollisionEventHandler.OnSliverExitEvent += Unparent;
    }

    void Parent() {
        this.transform.parent = GameObject.Find("Kidney").gameObject.transform;
        isChild = true;
    }

    void Unparent() {
        this.transform.parent = null;
        isChild = false;
        //Debug.Log("Unparented");
    }

    private void Update()
    {
        if (isChild)
        {
            //transform.position = this.transform.parent.position;
            //transform.rotation = this.transform.parent.rotation;
        }
    }

}
