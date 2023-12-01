using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGo : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (!CheckCollisionWithLayer(6))
        {
            //Transform myTransform = GetComponent<Transform>();
            Vector3 currentPosition = transform.position;
            currentPosition.x -= this.speed * Time.deltaTime;
            transform.position = currentPosition;
            findChild("Parent").GetComponent<Animator>().SetBool("eat", false);
        }
        else
        {
            findChild("Parent").GetComponent<Animator>().SetBool("eat", true);
        }

    }

    private GameObject findChild(String name)
    {
        Transform childTransform = transform.Find(name);
        GameObject childObject = null;
        if (childTransform != null) {
            childObject = childTransform.gameObject;
        } else
        {
            childObject = gameObject;
        }
        return childObject;
        
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
