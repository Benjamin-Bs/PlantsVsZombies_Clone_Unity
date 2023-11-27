using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlant : MonoBehaviour
{
    public static GameObject chosenPlant;
    
    void Start()
    {
        chosenPlant = Resources.Load<GameObject>("/Assets/Prefabs/Plants/Peashooter.prefab"); 
        Debug.Log(chosenPlant);
    }
    
    void Update()
    {
        //GameObject prefabToInstantiate = Resources.Load<GameObject>("Assets/Prefabs/Plants/Peashooter.prefab");
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
        {
            chosenPlant = Resources.Load<GameObject>("/Assets/Prefabs/Plants/Peashooter.prefab");    
            
        }
        else
        {
            chosenPlant = Resources.Load<GameObject>("/Assets/Prefabs/Plants/Double_Peashooter.prefab");
        }
        Debug.Log(chosenPlant);
        
    }
}
