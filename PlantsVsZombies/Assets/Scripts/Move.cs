using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;

    public float duration = 2.0f; 

    private float elapsedTime = 0f;

    void Start()
    {
        transform.position = startPoint;
        duration = Vector3.Distance(startPoint, endPoint);
    }
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        transform.position = Vector3.Lerp(startPoint, endPoint, t);
    }
}