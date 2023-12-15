using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Object = UnityEngine.Object;

public class PlaceZombie : MonoBehaviour
{
    [SerializeField]
    private GameObject zombie;

    [SerializeField] 
    private Grid grid;
    
    //private GameObject myIndicator;

    
    /*private void Start() {
        this.myIndicator = Object.Instantiate(this.zombie);
    }*/
    
    /*void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3Int position = this.grid.WorldToCell(mousePosition);
        position.x = 8;
        Vector3 worldPosition = this.grid.GetCellCenterWorld(position);
        worldPosition.z = 0;
        if (position.x >= 0 && position.x <= 8 && position.y >= 0 && position.y <= 4)
        {
            this.myIndicator.transform.position = worldPosition;

            if (Input.GetMouseButtonDown(0))
            {
                // place new Zombie
                GameObject newZombie = Object.Instantiate(this.zombie, worldPosition, Quaternion.identity);
                Vector3 vector3 = newZombie.transform.position;
                vector3.z = -5+position.y;
                newZombie.transform.position = vector3;
                
                ZombieGo myScriptComponent = newZombie.AddComponent<ZombieGo>();
                
                /*BoxCollider2D boxCollider = newZombie.AddComponent<BoxCollider2D>();
                newZombie.layer = 7;
                boxCollider.size = new Vector2(grid.cellSize.x, grid.cellSize.y);*
                
                SetLayerRecursive(newZombie, 10*(10-position.y));
            }
        }
    }*/

    public void place(int row)
    {
        
        Vector3Int position = new Vector3Int(8, row, 0);
        Vector3 worldPosition = this.grid.GetCellCenterWorld(position);
        worldPosition.z = 0;
        
        //this.myIndicator.transform.position = worldPosition;

        
        // place new Zombie
        GameObject newZombie = Object.Instantiate(this.zombie, worldPosition, Quaternion.identity);
        Vector3 vector3 = newZombie.transform.position;
        vector3.z = -5+position.y;
        newZombie.transform.position = vector3;
        
        ZombieGo myScriptComponent = newZombie.AddComponent<ZombieGo>();
        
        /*BoxCollider2D boxCollider = newZombie.AddComponent<BoxCollider2D>();
        newZombie.layer = 7;
        boxCollider.size = new Vector2(grid.cellSize.x, grid.cellSize.y);*/
        
        SetLayerRecursive(newZombie, 10*(10-position.y));
        
        
    }
    
    void SetLayerRecursive(GameObject obj, int layer)
    {
        Action<SpriteRenderer> function = spriteRenderer =>
        {
            spriteRenderer.sortingOrder += layer;
        };
        GameObjectUtility.SetRecursive(obj, function);
    }
}
