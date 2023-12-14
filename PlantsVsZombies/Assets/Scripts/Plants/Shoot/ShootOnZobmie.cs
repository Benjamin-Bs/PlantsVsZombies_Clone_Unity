using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

public class ShootOnZombie : MonoBehaviour
{
    [SerializeField] 
    private GameObject projectile;

    public GameObject zombie;
    
    public void Shoot1Projectile()
    {
        placeProjectile(projectile);
    }
    
    public void Shoot2ProjectilesAlternating(GameObject secondaryObject)
    {
        Random random = new Random();
        GameObject chosenObject = random.Next(0, 4) != 0 ? projectile : secondaryObject;
        placeProjectile(chosenObject);
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
            curvedFlight.Zombie = this.zombie;
        }
    }
}
