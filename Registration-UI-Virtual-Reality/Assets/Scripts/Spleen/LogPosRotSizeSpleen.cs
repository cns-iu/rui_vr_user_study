using UnityEngine;

public class LogPosRotSizeSpleen : MonoBehaviour
{
    public Transform origin;
    public Transform slab;
    float scalingFactor;

    private void Update()
    {
        scalingFactor = 120f / 0.91f;
       
        float[] distances = GetDistance(slab.position);
        float[] dimensions = GetSize(slab.localScale);
        float[] rotation = GetRotation(slab);

        Debug.Log("position: (" + distances[0].ToString("F0") + "," + distances[1].ToString("F0") + "," + distances[2].ToString("F0") + ")");
        Debug.Log("dimensions: (" + dimensions[0].ToString("F0") + "," + dimensions[1].ToString("F0") + "," + dimensions[2].ToString("F0") + ")");
        Debug.Log("rotation: (" + rotation[0].ToString("F0") + "," + rotation[1].ToString("F0") + "," + rotation[2].ToString("F0") + ")");
    }

    float[] GetDistance(Vector3 position)
    {
        float[] distances = new float[3];
        distances[0] = Mathf.Abs(position.x - origin.position.x) * scalingFactor;
        distances[1] = Mathf.Abs(position.y - origin.position.y) * scalingFactor;
        distances[2] = Mathf.Abs(position.z - origin.position.z) * scalingFactor;
        return distances;
    }

    float[] GetSize(Vector3 scale)
    {
        float[] dimensions = new float[3];
        dimensions[0] = scale.x * scalingFactor;
        dimensions[1] = scale.y * scalingFactor;
        dimensions[2] = scale.z * scalingFactor;
        return dimensions;
    }

    float[] GetRotation(Transform t)
    {
        float[] rotation = new float[3];
        
        rotation[0] = UnityEditor.TransformUtils.GetInspectorRotation(t).x;
        rotation[1] = UnityEditor.TransformUtils.GetInspectorRotation(t).y;
        rotation[2] = UnityEditor.TransformUtils.GetInspectorRotation(t).z;
        return rotation;
    }
    
}
