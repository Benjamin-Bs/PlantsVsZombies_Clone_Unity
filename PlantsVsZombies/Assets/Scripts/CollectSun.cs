using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 


public class CollectSun : MonoBehaviour
{
    private int sunScore = 0;
    [SerializeField]
    private Text mytext;

    // Start is called before the first frame update
    void Start()
    {
        mytext = GetComponent<Text>();
    }

    private void OnMouseDown()
    {
        sunScore += 25;
        if (mytext != null)
        {
            mytext.text = "SunScore : "+ sunScore.ToString();
        }
        Debug.Log(sunScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}