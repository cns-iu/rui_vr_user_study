using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    public Material mat_OutOfGrid;
    public Material mat_OnGrid;

    private void OnEnable()
    {
        CoordinateSystemControl.SliverGridEvent += AdjustMaterial;
    }

    private void OnDisable()
    {
        CoordinateSystemControl.SliverGridEvent -= AdjustMaterial;
    }

    void AdjustMaterial(bool isOnGrid) {
        //Debug.Log(isOnGrid);
        if (isOnGrid)
        {
            this.GetComponent<Renderer>().material = mat_OnGrid;
        }
        else
        {
            this.GetComponent<Renderer>().material = mat_OutOfGrid;
        }
        
    }
}
