using System;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

public class SpawnSunFromSky : MonoBehaviour
{
    [SerializeField] 
    private GameObject sun;

    private const int DELAY = 10;
    void Start()
    {
        Invoke("spawnSun", DELAY/2);
    }

    private void spawnSun()
    {
        float x = Random.Range(-4.5f, 1.5f);
        float y = Random.Range(-2.0f, 2.0f);
        Move move = Instantiate(sun).AddComponent<Move>();
        move.startPoint = new Vector3(x, 3.5f, -9);
        move.endPoint = new Vector3(x, y, -9);
        
        Invoke("spawnSun", DELAY + Random.Range(-2,2));
    }
}
