using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Zombie {
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string type;
    public string row;
    public string time;
}

[System.Serializable]
public class Zombies {
    //employees is case sensitive and must match the string "employees" in the JSON.
    public Zombie[] zombies;
}

public class JSONReader : MonoBehaviour {
    public TextAsset jsonFile;
    void Start() {
        Zombies zombiesInJson = JsonUtility.FromJson<Zombies>(jsonFile.text);
     
        foreach (Zombie zombie in employeesInJson.employees) {
            Debug.Log("Found zombie: " + zombie.type + " " + zombie.row);
        }
    }
}

