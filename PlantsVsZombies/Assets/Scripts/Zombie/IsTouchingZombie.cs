using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingZombie : MonoBehaviour
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
                if (hit.collider.gameObject.layer == 7)
                {
                    Debug.Log("You Lose");
                }
            }
        }
    }
}
