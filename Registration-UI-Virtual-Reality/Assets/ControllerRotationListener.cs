using UnityEngine;
using System.Collections;

public class ControllerRotationListener : MonoBehaviour
{
    public float rotationSpeed;

    private void OnEnable()
    {
        ControllerTabletopLeft.TouchPadSwipeActionEvent += RotateKidneyOnUserInput;
    }

    private void OnDisable()
    {
        ControllerTabletopLeft.TouchPadSwipeActionEvent -= RotateKidneyOnUserInput;
    }

    void RotateKidneyOnUserInput(RotationDirection rd)
    {
        //Debug.Log("receiving event");
        Transform t = this.transform;
        if (rd == RotationDirection.Clockwise)
        {
            t.Rotate(0f, 5f * Time.deltaTime * rotationSpeed, 0f);
        }
        else
        {
            t.Rotate(0f, -5f * Time.deltaTime * rotationSpeed, 0f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
