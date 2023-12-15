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
        instance.transform.position = vector3;
    }
}
