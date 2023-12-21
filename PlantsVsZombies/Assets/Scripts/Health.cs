using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int health;

    [SerializeField] 
    private int[] spriteHealths;

    private void Start()
    {
        Array.Sort(spriteHealths);
        Array.Reverse(spriteHealths);
        updateHealthTrigger();
    }

    public void decreaseHealth(int amount)
    {
        health -= amount;
        updateHealthTrigger();
        changeSpriteByHealth();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void kill()
    {
        Destroy(gameObject);
    }

    private void updateHealthTrigger()
    {
        try
        {
            GameObject parent =  GameObjectUtility.findChild(gameObject, "Parent");
            parent.GetComponent<Animator>().SetInteger("health", health);
            Debug.Log(health);
        }
        catch (Exception e)
        {
            
        }
    }

    private void changeSpriteByHealth()
    {
        try
        {
            int index = 0;
            for (int i = 0; i < spriteHealths.Length; i++)
            {
                if (health < spriteHealths[i])
                {
                    Debug.Log(health+": "+spriteHealths[i]);
                    index = i;
                }
            }
            for (int j = 0; j < spriteHealths.Length; j++)
            {
                GameObjectUtility.findChild(gameObject, "Sprite_" + (j+1)).GetComponent<SpriteRenderer>().enabled = false;
            }
            Debug.Log("Sprite_" + (index+1));
            GameObjectUtility.findChild(gameObject, "Sprite_" + (index+1)).GetComponent<SpriteRenderer>().enabled = true;
        }
        catch (Exception e)
        {
            
        }
    }
}
