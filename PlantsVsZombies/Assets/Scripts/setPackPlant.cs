using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;

public class setPackPlant : MonoBehaviour
{
    [SerializeField] 
    private GameObject plant;
    
    private PlacePlant placer;

    private void Awake()
    {
        placer = GameObject.Find("Controller").GetComponent<PlacePlant>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject icon = GameObjectUtility.findChild(gameObject, "Icon");
        icon.GetComponent<SpriteRenderer>().sprite = plant.GetComponent<setPlantInformation>().icon;

        GameObject canvas = GameObjectUtility.findChild(gameObject, "Canvas");
        GameObject costText = GameObjectUtility.findChild(canvas, "CostText");
        costText.GetComponent<TextMeshProUGUI>().text = plant.GetComponent<setPlantInformation>().cost.ToString();
    }

    private void OnMouseDown()
    {
        placer.SetPlant(plant);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
