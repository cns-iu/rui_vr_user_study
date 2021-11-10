using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateSystemControl : MonoBehaviour
{
    public GameObject sliver;
    public GameObject coordinateSystem;
    public Vector3 normalizedPosition;
    public Vector3 normalizedSize;
    public List<string> coords = new List<string>();
    public Text sliverPosIndicator;
    public Text outOfBoundsWarning;
    public float[][] limits = new float[2][];
    public Font thin;

    public delegate void SliverGrid(bool isOnGrid);
    public static event SliverGrid SliverGridEvent;

    Vector3 sliverPosition;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        coordinateSystem = this.gameObject;
        coords.Add("letter");
        coords.Add("number");
        coords.Add("roman");
    }

    // Update is called once per frame
    void Update()
    {
        sliverPosition = sliver.transform.position;
        origin = coordinateSystem.transform.position;
        normalizedPosition = new Vector3(
            ConvertToMetric(NormalizePosition())[0],
            ConvertToMetric(NormalizePosition())[1],
            ConvertToMetric(NormalizePosition())[2]
            ) * 2f;
        normalizedSize = new Vector3(
            ConvertToMetric(NormalizePosition())[0],
            ConvertToMetric(NormalizePosition())[1],
            ConvertToMetric(NormalizePosition())[2]
            );
        //Debug.Log(normalizedPosition);
        SetUIText();
        SetCoords();
    }

    Vector3 NormalizePosition()
    {
        normalizedPosition = sliverPosition - origin;
        normalizedPosition[0] = RoundToNDecimals(normalizedPosition[0] * 2f * 10f);//invert z-position
        normalizedPosition[1] = RoundToNDecimals(normalizedPosition[1] * (-2f) * 10f); //invert y-position
        normalizedPosition[2] = RoundToNDecimals(normalizedPosition[2] * (-2f) * 10f);//invert z-position
        //Debug.Log(normalizedPosition[2]);
        //Debug.Log("return for normalizedPosition x: " + normalizedPosition.x );
        return normalizedPosition;
    }

    float[] ConvertToMetric(Vector3 ToNormalizeValue)
    {
        float[] metricPositions = new float[3];
        for (int i = 0; i < metricPositions.Length; i++)
        {
            metricPositions[i] = ToNormalizeValue[i] * 2f;
        }
        return metricPositions;
    }

    void SetUIText()
    {
        string text = "";
        if (normalizedPosition[0] >= 0f && normalizedPosition[0] <= 60f && normalizedPosition[1] >= 0f && normalizedPosition[1] <= 100f)
        {
            if (SliverGridEvent != null)
            {
                SliverGridEvent(true);
            }

            text = text 
                + "X: <b>" + normalizedPosition.x + "</b>\n"
                + "Y: <b>" + normalizedPosition.y + "</b>\n"
                + "Z: <b>" + normalizedPosition.z + "</b>";
        }
        else
        {
            text = text
                + "X: 0.00" + "\n"
                + "Y: 0.00" + "\n"
                + "Z: 0.00";
            //sliverPosIndicator.text = outOfBoundsWarning.text;
            SliverGridEvent(false);
        }
        sliverPosIndicator.text = text;
        sliverPosIndicator.font = thin;
        coords = SetCoords();
    }

    float RoundToNDecimals(float x)
    {
        return Mathf.Round(x * 100f) / 100f;
    }

    List<string> SetCoords()
    {
        List<string> coords = new List<string>();
        if (normalizedPosition.x < 1f)
        {
            coords.Add("A");
        }

        return coords;
    }
}
