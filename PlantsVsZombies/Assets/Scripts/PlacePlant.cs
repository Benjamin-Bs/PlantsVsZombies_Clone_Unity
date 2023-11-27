using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlacePlant : MonoBehaviour
{
    [SerializeField]
    private GameObject plant;

    [SerializeField] 
    private Grid grid;
    
    private GameObject myIndicator;

    
    private void Start() {
        this.myIndicator = Object.Instantiate(this.plant);
    }
    
    void Update()
    {
        // setCellPosition to MousePosition
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3Int position = this.grid.WorldToCell(mousePosition);
        Vector3 worldPosition = this.grid.GetCellCenterWorld(position);
        worldPosition.z = 0;
        if (position.x >= 0 && position.x <= 8 && position.y >= 0 && position.y <= 4)
        {
            //Debug.Log(Physics2D.OverlapPointAll(mousePosition));
            if (Physics2D.OverlapPoint(mousePosition, 6))
            {
                Debug.Log("in");
            }
            this.myIndicator.transform.position = worldPosition;

            if (Input.GetMouseButtonDown(0))
            {
                // place new Plant
                GameObject newPlant = Object.Instantiate(this.plant, worldPosition, Quaternion.identity);
                
                
                BoxCollider2D boxCollider = newPlant.AddComponent<BoxCollider2D>();
                newPlant.layer = 6;
                boxCollider.size = new Vector2(10f, 10f);
                Debug.Log(boxCollider.transform.position);
                
                SetLayerRecursive(newPlant, 10*(10-position.y));
            }
        }
    }
    
    void SetLayerRecursive(GameObject obj, int layer)
    {
        // Set the layer for the current GameObject
        
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder += layer;
        }

        // Iterate through all children and set their layers
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursive(child.gameObject, layer);
        }
    }
}
