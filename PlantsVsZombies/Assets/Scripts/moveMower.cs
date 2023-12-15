using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class moveMower : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;

    [SerializeField]
    private Animator animator;

    private bool hasCollided;

    void Update()
    {
        GameObject collisionObject = CollisionDetection.FindCollisionWithLayer(gameObject, 7);

        if (!(collisionObject == null || collisionObject.transform.position.z != transform.position.z))
        {
            hasCollided = true;
            animator.SetBool("started",true);
            
            //Transform myTransform = GetComponent<Transform>();
            collisionObject.GetComponent<Health>().kill();
        }
        
        if (hasCollided)
        {
            move();
        }
    }

    public void move()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += this.speed * Time.deltaTime;
        transform.position = currentPosition;
    }
    
    
    
}