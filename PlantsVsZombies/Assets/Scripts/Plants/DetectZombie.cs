using System;
using UnityEngine;

public class DetectZombie : MonoBehaviour
{
    [SerializeField] 
    private int fieldRange = 9;
        
        
    void Start()
    {
            
    }
        
    void Update()
    {
        if (!CheckCollisionWithLayer(7))
        {
            findChild("Parent").GetComponent<Animator>().SetBool("hasDetectedZombie", false);
        }
        else
        {
            findChild("Parent").GetComponent<Animator>().SetBool("hasDetectedZombie", true);
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
            childObject = null;
        }
        return childObject;
            
    }
        
    private bool CheckCollisionWithLayer(int layer)
    {
        GameObject child = findChild("detectZombie");
        if (child != null)
        {
            BoxCollider2D collider = child.GetComponent<BoxCollider2D>();
            Collider2D[] colliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0f);

            foreach (Collider2D col in colliders)
            {
                if (col.gameObject.layer == layer)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
