using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class ZombieGo : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    
    void Update()
    {
        bool hasCollision = CollisionDetection.HasCollisionWithLayer(gameObject, 6);
        if (!hasCollision)
        {
            //Transform myTransform = GetComponent<Transform>();
            Vector3 currentPosition = transform.position;
            currentPosition.x -= this.speed * Time.deltaTime;
            transform.position = currentPosition;
        }
        GameObjectUtility.findChild(gameObject,"Parent").GetComponent<Animator>().SetBool("eat", hasCollision);
    }
}
