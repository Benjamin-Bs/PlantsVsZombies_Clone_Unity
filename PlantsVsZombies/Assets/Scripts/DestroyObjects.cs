using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class DestroyObjects : MonoBehaviour
{
    
    private EdgeCollider2D borderCollider;

    void Start()
    {
        borderCollider = GetComponent<EdgeCollider2D>();
    }
    
    void Update()
    {
        Vector2[] points = borderCollider.points;

        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector2 startPoint = borderCollider.transform.TransformPoint(points[i]);
            Vector2 endPoint = borderCollider.transform.TransformPoint(points[i + 1]);

            RaycastHit2D[] hits = Physics2D.LinecastAll(startPoint, endPoint);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.layer != 9)
                {
                    Debug.Log(hit.collider.gameObject);
                    GameObject.Destroy(hit.collider.gameObject);
                }
            }
        }
    }

}
