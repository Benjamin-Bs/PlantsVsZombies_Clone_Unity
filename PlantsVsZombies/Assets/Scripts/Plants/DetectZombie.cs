using System;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Utility;

public class DetectZombie : MonoBehaviour
{
    void Update()
    {
        GameObject child = GameObjectUtility.findChild(gameObject, "Parent");
        GameObject firstZombie = 
            CollisionDetection.FindCollisionWithLayer(GameObjectUtility.findChild(gameObject, "detectZombie"), 7);
        child.GetComponent<Animator>().SetBool(
            "hasDetectedZombie", 
            (firstZombie != null)
        );
        child.GetComponent<ShootOnZombie>().zombie = firstZombie;
    }
    
}
