using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Zombie {
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string type;
    public int row;
    public float time;
}

[System.Serializable]
public class Zombies {
    //employees is case sensitive and must match the string "employees" in the JSON.
    public Zombie[] zombies;
}

public class jsonReader : MonoBehaviour
{
    [SerializeField] 
    private TextAsset jsonFile;

    [SerializeField] 
    private PlaceZombie placer;

    private float timer = 0;
    private Zombie[] zombieArray;
    private int nextIndex = 0;

    void Start()
    {
        Zombies zombiesInJson = JsonUtility.FromJson<Zombies>(jsonFile.text);

        zombieArray = (Zombie[])zombiesInJson.zombies.Clone();
        
        foreach (Zombie zombie in zombiesInJson.zombies)
        {
            float delay = zombie.time - Time.time;
            Invoke("PlaceZombie", delay);
        }
    }

    private void PlaceZombie()
    {
        Zombie currentZombie = zombieArray[nextIndex];
        placer.place(currentZombie.row);
        Debug.Log(Time.time);
        nextIndex++;
    }
}

