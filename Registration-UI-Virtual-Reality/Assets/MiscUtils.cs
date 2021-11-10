using UnityEngine;
using UnityEngine.UI;

public class MiscUtils : MonoBehaviour
{
    public Toggle previewToggle;

    // Start is called before the first frame update
    void Start()
    {
        previewToggle.onValueChanged.AddListener(delegate
        {

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
