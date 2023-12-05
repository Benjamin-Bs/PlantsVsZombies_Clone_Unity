using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootOnZombie : MonoBehaviour
{
    [SerializeField] 
    private GameObject projectile;

    public GameObject zombie;
    
    public void Shoot1Projectile()
    {
        placeProjectile(projectile);
    }

    private int counter;
    public void Shoot2ProjectilesAlternating(GameObject secondaryObject, int firstTime, int length)
    {
        GameObject chosenObject = (counter%firstTime < length) ? projectile : secondaryObject;
        placeProjectile(chosenObject);
        counter++;
    }

    private void placeProjectile(GameObject chosenPrefab)
    {
        Vector3 vector = gameObject.transform.position;
        vector.x += 0.4f;
        vector.y += 0.45f;
        chosenPrefab.transform.position = vector;
        
        GameObject instance = Object.Instantiate(chosenPrefab);
        CurvedFlight curvedFlight = instance.GetComponent<CurvedFlight>();
        if (curvedFlight != null)
        {
            curvedFlight.zombie = this.zombie;
        }
    }
}
