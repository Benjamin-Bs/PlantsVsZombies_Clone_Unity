using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utility;

public class Patotoemine : MonoBehaviour
{
    private Animator animator;

    private int mode = 0;
    private DateTime placetime;
    private DateTime detonatedtime;
    private bool hascollided;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        placetime = DateTime.Now;
        hascollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject collisionObject = CollisionDetection.FindCollisionWithLayer(gameObject, 7);

        if (!(collisionObject == null || collisionObject.transform.position.z != transform.position.z))
        {
            hascollided = true;
            collisionObject.GetComponent<Health>().kill();
        }
        
        if (animator != null)
        {
            if ((DateTime.Now - placetime).TotalSeconds >= 15 && mode==0)
            {
                animator.SetTrigger("Grow");
                mode++;
            }
            

            if (hascollided && mode == 1)
            {
                animator.SetTrigger("Explode");
                mode++;
                detonatedtime = DateTime.Now;
                Invoke("destroy",2);
            }
        }

        
    }

    void destroy()
    {
        Destroy(gameObject);
    }
    
    
}
