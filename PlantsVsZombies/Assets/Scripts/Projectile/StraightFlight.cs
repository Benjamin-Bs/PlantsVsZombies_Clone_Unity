using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFlight : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (!CheckCollisionWithLayer(7))
        {
            //Transform myTransform = GetComponent<Transform>();
            Vector3 currentPosition = transform.position;
            currentPosition.x += this.speed * Time.deltaTime;
            transform.position = currentPosition;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    private bool CheckCollisionWithLayer(int layer)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Collider2D[] colliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0f);
        
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.layer == layer)
            {
                return true;
            }
        }
        return false;
    }
}
