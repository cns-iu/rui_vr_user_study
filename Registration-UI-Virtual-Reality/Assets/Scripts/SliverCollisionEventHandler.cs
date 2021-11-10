using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliverCollisionEventHandler : MonoBehaviour
{
    public delegate void OnSliverEnter();
    public static event OnSliverEnter OnSliverEnterEvent;
    public delegate void OnSliverExit();
    public static event OnSliverExit OnSliverExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (OnSliverEnterEvent != null)
        {
            OnSliverEnterEvent();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (OnSliverExitEvent != null)
        {
            OnSliverExitEvent();
        }
    }
}
