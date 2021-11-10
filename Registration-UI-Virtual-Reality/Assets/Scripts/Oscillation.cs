using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    public float amp;

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        StartCoroutine(Oscillate());
    }

    IEnumerator Oscillate() {
        transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time) * amp, 0.0f, 0.0f);
        yield return null;
    }
}
