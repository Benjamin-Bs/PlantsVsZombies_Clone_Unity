using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;
using Object = UnityEngine.Object;

public class PlaceMower : MonoBehaviour
{
     [SerializeField]
     private GameObject mower;

    [SerializeField] 
    private Grid grid;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            place(i);
        }
    }

    public void place(int row)
    {
        Vector3Int position = new Vector3Int(-1, row, 0);
        Vector3 worldPosition = this.grid.GetCellCenterWorld(position);
        worldPosition.z = 0;

        //this.myIndicator.transform.position = worldPosition;


        // place new Mower
        GameObject newMower = Object.Instantiate(this.mower, worldPosition, Quaternion.identity);
        Vector3 vector3 = newMower.transform.position;
        vector3.z = -5 + position.y;
        newMower.transform.position = vector3;
        
        /*BoxCollider2D boxCollider = newZombie.AddComponent<BoxCollider2D>();
        newZombie.layer = 7;
        boxCollider.size = new Vector2(grid.cellSize.x, grid.cellSize.y);*/

        SetLayerRecursive(newMower, 10 * (10 - position.y));
    }

    void SetLayerRecursive(GameObject obj, int layer)
    {
        Action<SpriteRenderer> function = spriteRenderer => { spriteRenderer.sortingOrder += layer; };
        GameObjectUtility.SetRecursive(obj, function);
    }
}