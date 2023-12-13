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
    private TMP_Text mytext;


    private void OnMouseDown()
    {
        sunScore += 25;
        mytext.text = sunScore.ToString();
        Debug.Log(sunScore);

        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}