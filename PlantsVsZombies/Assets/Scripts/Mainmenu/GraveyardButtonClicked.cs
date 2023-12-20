using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GraveyardButtonClicked : MonoBehaviour
{
    [SerializeField] 
    private GameObject glowingGraveyardButton;
    [SerializeField] 
    private String sceneName;
    private Button button;
    private float pressTime;
    private bool delayStarted = false;
    private readonly float DELAY = 0.6f;
    private float delayTimer = 0;
    private bool buttonReleased = false;
    

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonRelease);

        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry pressEntry = new EventTrigger.Entry();
        pressEntry.eventID = EventTriggerType.PointerDown;
        pressEntry.callback.AddListener((data) => { OnButtonPress(); });
        trigger.triggers.Add(pressEntry);


        EventTrigger.Entry releaseEntry = new EventTrigger.Entry();
        releaseEntry.eventID = EventTriggerType.PointerUp;
        releaseEntry.callback.AddListener((data) => { OnButtonRelease(); });
        trigger.triggers.Add(releaseEntry);
    }

    void OnButtonPress()
    {
        glowingGraveyardButton.SetActive(true);
        delayStarted = true;
    }

    void OnButtonRelease()
    {
        buttonReleased = true;
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if (delayStarted)
        {
            delayTimer += Time.deltaTime;

            if (delayTimer >= DELAY)
            {
                if (buttonReleased)
                {
                    glowingGraveyardButton.SetActive(false);
                    buttonReleased = false;
                    delayStarted = false;
                    delayTimer = 0;
                }
            }
        }
    }
}