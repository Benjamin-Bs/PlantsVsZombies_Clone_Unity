using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatPlant : MonoBehaviour
{
    [SerializeField] 
    private int damage;

    public GameObject plant;


    public void eat()
    {
        plant.GetComponent<Health>().decreaseHealth(damage);
    }
    
}
