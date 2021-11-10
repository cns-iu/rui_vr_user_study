using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class URLClickHandler : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void openPage(string url);

    public Button[] btns;

    public void OpenURL(string url) {
        //Debug.Log(url);
        openPage(url);
    }
}
