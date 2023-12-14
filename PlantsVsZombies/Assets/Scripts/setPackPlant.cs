using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;

public class setPackPlant : MonoBehaviour
{
    [SerializeField] 
    private GameObject plant;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObjectUtility.findChild(gameObject, "Icon").GetComponent<SpriteRenderer>().sprite = plant.GetComponent<setPlantInformation>().icon;

        GameObject canvas = GameObjectUtility.findChild(gameObject, "Canvas");
        GameObject costText = GameObjectUtility.findChild(canvas, "CostText");
        costText.GetComponent<TextMeshProUGUI>().text = plant.GetComponent<setPlantInformation>().cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
