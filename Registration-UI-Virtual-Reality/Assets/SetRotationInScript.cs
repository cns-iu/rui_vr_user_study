using UnityEngine;

public class SetRotationInScript : MonoBehaviour
{
    public float a;
    public float b;
    public float c;

    private void OnValidate()
    {
        transform.rotation = Quaternion.Euler(a, b, c);
    }
}
