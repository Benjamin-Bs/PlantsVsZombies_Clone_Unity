using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;


public class CollectSun : MonoBehaviour
{
    
    private Money money;
    
    private void Awake()
    {
        money = GameObject.Find("Selectbar").GetComponent<Money>();
    }
    
    private void OnMouseDown()
    {
        money.increase(25);

        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}