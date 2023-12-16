using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class SpawnSun : MonoBehaviour
{
    [SerializeField] 
    private GameObject sun;
    
    void spawn()
    {
        
        GameObject instance = Instantiate(sun);
        
        Vector3 vector3 = gameObject.transform.position;
        VectorUtility.setX(instance, vector3.x + Random.Range(-0.2f, 0.2f));
        VectorUtility.setY(instance, vector3.y + Random.Range(-0.2f, 0.2f));
    }
}
