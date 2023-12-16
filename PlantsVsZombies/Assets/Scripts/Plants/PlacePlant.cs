using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

public class PlacePlant : MonoBehaviour
{
    private GameObject plant = null;

    [SerializeField] 
    private Grid grid;

    [SerializeField]
    private Money money;
    
    private GameObject myIndicator;
    private int range = 8;

    
    
    
    public void SetPlant(GameObject plant)
    {
        
        this.plant = (this.plant == plant) ? null : plant;

        if (this.myIndicator != null)
        {
            Object.Destroy(this.myIndicator.gameObject);
        }

        if (this.plant != null)
        {
            if (money.canDecrease(this.plant.GetComponent<setPlantInformation>().cost))
            {
                this.myIndicator = Object.Instantiate(this.plant);
                Action<SpriteRenderer> function = spriteRenderer =>
                {
                    Color color = spriteRenderer.color;
                    color.a = 0.5f;
                    spriteRenderer.color = color;
                };
                GameObjectUtility.SetRecursive(myIndicator.gameObject, function);
            }
        }
    }
    
    void Update()
    {
        if (plant != null)
        {

            // setCellPosition to MousePosition
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3Int position = this.grid.WorldToCell(mousePosition);
            Vector3 worldPosition = this.grid.GetCellCenterWorld(position);
            worldPosition.z = 0;
            if (position.x >= 0 && position.x <= 8 && position.y >= 0 && position.y <= 4)
            {
                if (!hitsLayer(6))
                {
                    if (myIndicator != null)
                    {
                        myIndicator.transform.position = worldPosition;
                    }
                    

                    if (Input.GetMouseButtonDown(0))
                    {
                        try
                        {
                            money.decrease(plant.GetComponent<setPlantInformation>().cost);
                            
                            // place new Plant
                            GameObject newPlant = Object.Instantiate(plant, worldPosition, Quaternion.identity);
                            VectorUtility.setZ(newPlant, -5+position.y);

                            // add hitbox (collider)
                            BoxCollider2D boxCollider = newPlant.AddComponent<BoxCollider2D>();
                            newPlant.layer = 6;
                            boxCollider.size = new Vector2(grid.cellSize.x + 0.02f, grid.cellSize.y + 0.02f);
                        
                            // add zombieInRow collider
                            GameObject child = new GameObject("detectZombie");
                            child.transform.parent = newPlant.transform;
                            BoxCollider2D zombieInRowCollider = child.AddComponent<BoxCollider2D>();
                            child.transform.position = new Vector3(worldPosition.x + grid.cellSize.x * range/2, worldPosition.y,-5+position.y);
                            zombieInRowCollider.size = new Vector2(grid.cellSize.x * (range + 1), grid.cellSize.y);
                            child.layer = 8;
                        
                            Action<SpriteRenderer> function = (spriteRenderer) =>
                            {
                                spriteRenderer.sortingOrder += 10 * (10 - position.y);
                            };
                            GameObjectUtility.SetRecursive(newPlant, function);
                            
                            SetPlant(null);
                        }
                        catch (MoneyException)
                        {
                            //do nothing
                        }
                    }
                }
            }
        }
    }

    private bool hitsLayer(int layer)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);
                
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.gameObject.layer == layer)
            {
                return  true;
            }
        }

        return false;
    }
    
}
