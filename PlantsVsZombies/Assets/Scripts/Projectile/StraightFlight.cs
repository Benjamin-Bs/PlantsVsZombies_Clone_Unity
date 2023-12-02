using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFlight : MonoBehaviour
{
    [SerializeField] 
    private int damage = 40;
    [SerializeField] 
    private float speed = 0.5f;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        GameObject collisionObject = FindCollisionWithLayer(7);
        if (collisionObject == null)
        {
            //Transform myTransform = GetComponent<Transform>();
            Vector3 currentPosition = transform.position;
            currentPosition.x += this.speed * Time.deltaTime;
            transform.position = currentPosition;
        }
        else
        {
            collisionObject.GetComponent<Health>().decreaseHealth(30);
            Destroy(gameObject);
        }

    }
    
    private GameObject FindCollisionWithLayer(int layer)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Collider2D[] colliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0f);
        
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.layer == layer)
            {
                return col.gameObject;
            }
        }
        return null;
    }
}
