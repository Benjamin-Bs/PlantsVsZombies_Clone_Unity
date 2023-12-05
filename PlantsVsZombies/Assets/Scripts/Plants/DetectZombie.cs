using System;
using UnityEngine;
using Utility;

public class DetectZombie : MonoBehaviour
{
    void Update()
    {
        GameObjectUtility.findChild(gameObject, "Parent").GetComponent<Animator>().SetBool(
            "hasDetectedZombie", 
            CollisionDetection.HasCollisionWithLayer(GameObjectUtility.findChild(gameObject, "detectZombie"),7)
        );
    }
    
}
