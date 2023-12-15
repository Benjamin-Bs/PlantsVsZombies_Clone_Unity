using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;


public class CollectSun : MonoBehaviour
{
    
    private GameObject score;
    
    private void Awake()
    {
        score = GameObject.Find("Score");
    }
    
    private void OnMouseDown()
    {
        TextMeshProUGUI textMesh = score.GetComponent<TextMeshProUGUI>();
        Debug.Log((int.Parse(textMesh.text)+25).ToString());
        textMesh.text = (int.Parse(textMesh.text)+25).ToString();

        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}