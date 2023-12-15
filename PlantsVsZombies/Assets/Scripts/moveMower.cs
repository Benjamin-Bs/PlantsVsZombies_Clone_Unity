using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMower : MonoBehaviour
{
    public float speed = 5f; // Geschwindigkeit der Bewegung

    void Update()
    {
        // Bewegung in horizontaler Richtung
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Berechne die Verschiebung
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;

        // Bewege das Objekt
        transform.Translate(movement);
    }
}
