using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class CurvedFlight : MonoBehaviour
{
    
    [SerializeField] 
    private int damage = 40;
    [SerializeField] 
    private float height = 3;

    private GameObject zombie;
    public GameObject Zombie 
    {
        get
        {
            return zombie;
        }
        set
        {
            if (zombie == null)
            {
                zombie = value;
            }
        }
    }
    
    private const float GRAVITY = 10;
    private float speedY = 7;
    private float speedX = 2;
    private float time;

    public void Start()
    {
        if (zombie != null)
        {
            this.time = speedY/GRAVITY;
            this.speedX = (zombie.transform.position.x - (zombie.GetComponent<ZombieGo>().speed / 2) - transform.position.x) * time;
        }
        else
        {
            Destroy(gameObject);   
        }
        
    }

    void Update()
    {
        GameObject collisionObject = CollisionDetection.FindCollisionWithLayer(gameObject,7);
        if (collisionObject == null || collisionObject.transform.position.z != transform.position.z)
        {
            
            //Transform myTransform = GetComponent<Transform>();
            Vector3 currentPosition = transform.position;
            speedY -= (GRAVITY * Time.deltaTime);
            
            currentPosition.y += (speedY * Time.deltaTime);
            currentPosition.x += (speedX * Time.deltaTime);
            
            transform.position = currentPosition;
        }
        else
        {
            collisionObject.GetComponent<Health>().decreaseHealth(damage);
            Destroy(gameObject);    
        }
    }
}
