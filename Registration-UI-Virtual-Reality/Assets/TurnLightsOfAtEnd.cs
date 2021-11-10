using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightsOfAtEnd : MonoBehaviour
{
  

    private void OnEnable()
    {
        TaskManager.EndOfSessionEvent += TurnOff;   
    }

    private void OnDisable()
    {
        TaskManager.EndOfSessionEvent -= TurnOff;
    }

    void TurnOff() {
        gameObject.SetActive(false);
    }
}
