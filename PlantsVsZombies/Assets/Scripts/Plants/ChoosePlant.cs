using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlant : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] availablePlants;

    [SerializeField]
    private PlacePlant placer;
    
    private GameObject chosenPlant;
    private int i = 0;
    

    void Start()
    {
        chosenPlant = availablePlants[2]; 
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            placer.SetPlant(availablePlants[i]);
            i++;
            
            if (i >= availablePlants.Length)
            {
                i = 0;
            }
        }
    }
}
