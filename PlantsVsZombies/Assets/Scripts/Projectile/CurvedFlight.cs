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

    public GameObject zombie;
        
    void Update()
    {
        GameObject collisionObject = CollisionDetection.FindCollisionWithLayer(gameObject,7);
        int speed = 1;
        if (collisionObject == null || collisionObject.transform.position.z != transform.position.z)
        {
            //Transform myTransform = GetComponent<Transform>();
            Vector3 currentPosition = transform.position;
            currentPosition.x += speed * Time.deltaTime;
            transform.position = currentPosition;
        }
        else
        {
            collisionObject.GetComponent<Health>().decreaseHealth(30);
            Destroy(gameObject);    
        }
    }
}
