using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Object = UnityEngine.Object;

public class PlacePlant : MonoBehaviour
{
    private GameObject plant = null;

    [SerializeField] 
    private Grid grid;
    
    private GameObject myIndicator;
    
    public void SetPlant(GameObject plant)
    {
        this.plant = plant;
        Debug.Log(this.myIndicator != null);
        if (this.myIndicator != null)
        {
            Object.Destroy(this.myIndicator.gameObject);
        }
        this.myIndicator = Object.Instantiate(this.plant);
        SpriteRenderer spriteRenderer = this.myIndicator.GetComponent<SpriteRenderer>();
        Action<SpriteRenderer> function = spriteRenderer =>
        {
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
        };
        
        SetRecursive(myIndicator.gameObject ,function);
    }
    
    void Update()
    {
        Debug.Log(plant);
        if (plant != null)
        {

            // setCellPosition to MousePosition
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3Int position = this.grid.WorldToCell(mousePosition);
            Vector3 worldPosition = this.grid.GetCellCenterWorld(position);
            worldPosition.y -= 0.1f;
            worldPosition.z = 0;
            if (position.x >= 0 && position.x <= 8 && position.y >= 0 && position.y <= 4)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                if (hit.collider == null || hit.collider.gameObject.layer != 6)
                {
                    this.myIndicator.transform.position = worldPosition;

                    if (Input.GetMouseButtonDown(0))
                    {

                        // place new Plant
                        GameObject newPlant = Object.Instantiate(plant, worldPosition, Quaternion.identity);


                        BoxCollider2D boxCollider = newPlant.AddComponent<BoxCollider2D>();
                        newPlant.layer = 6;
                        boxCollider.size = new Vector2(grid.cellSize.x, grid.cellSize.y);
                        
                        // add zombie in row collider
                        GameObject child = new GameObject("detectZombie");
                        child.transform.parent = newPlant.transform;
                        BoxCollider2D zombieInRowCollider = child.AddComponent<BoxCollider2D>();
                        child.transform.position = new Vector3(worldPosition.x + grid.cellSize.x * 4, worldPosition.y,0);
                        zombieInRowCollider.size = new Vector2(grid.cellSize.x * 9, grid.cellSize.y);
                        child.layer = 8;
                        
                        Action<SpriteRenderer> function = (spriteRenderer) =>
                        {
                            spriteRenderer.sortingOrder += 10 * (10 - position.y);
                        };
                        SetRecursive(newPlant, function);

                    }
                }
            }
        }
    }
    
    void SetRecursive(GameObject obj, Action<SpriteRenderer> function)
    {
        // Set the layer for the current GameObject
        
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            function(spriteRenderer);
        }

        // Iterate through all children and set their layers
        foreach (Transform child in obj.transform)
        {
            SetRecursive(child.gameObject, function);
        }
    }
}
