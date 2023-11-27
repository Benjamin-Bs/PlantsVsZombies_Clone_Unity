using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class CollectSun : MonoBehaviour
{
    private int score = 0;
    public Text halloText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddSun()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            halloText.text = "Hallo Welt";
        }
    }
}