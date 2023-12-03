using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class StraightFlight : MonoBehaviour
{
    [SerializeField] 
    private int damage = 40;
    [SerializeField] 
    private float speed = 0.5f;
    
    
    void Update()
    {
        GameObject collisionObject = CollisionDetection.FindCollisionWithLayer(gameObject,7);
        if (collisionObject == null || collisionObject.transform.position.z != transform.position.z)
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
}
