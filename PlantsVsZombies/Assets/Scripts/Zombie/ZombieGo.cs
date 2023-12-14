using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class ZombieGo : MonoBehaviour
{
    [SerializeField] public float speed = 0.5f;
    
    void Update()
    {
        GameObject collisionObject = CollisionDetection.FindCollisionWithLayer(gameObject, 6);
        bool hasCollision = collisionObject != null;
        if (!hasCollision)
        {
            //Transform myTransform = GetComponent<Transform>();
            Vector3 currentPosition = transform.position;
            currentPosition.x -= this.speed * Time.deltaTime;
            transform.position = currentPosition;
        }

        GameObject child = GameObjectUtility.findChild(gameObject, "Parent");
        child.GetComponent<eatPlant>().plant = collisionObject;
        child.GetComponent<Animator>().SetBool("eat", hasCollision);
    }
}
