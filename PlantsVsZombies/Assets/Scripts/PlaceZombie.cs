using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceZombie : MonoBehaviour
{
    [SerializeField]
    private GameObject zombie;

    [SerializeField] 
    private Grid grid;
    
    private GameObject myIndicator;

    
    private void Start() {
        this.myIndicator = Object.Instantiate(this.zombie);
    }
    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3Int position = this.grid.WorldToCell(mousePosition);
        Vector3 worldPosition = this.grid.GetCellCenterWorld(position);
        worldPosition.z = 0;
        if (position.x >= 0 && position.x <= 8 && position.y >= 0 && position.y <= 4)
        {
            this.myIndicator.transform.position = worldPosition;

            if (Input.GetMouseButtonDown(0))
            {
                // place new Zombie
                GameObject newZombie = Object.Instantiate(this.zombie, worldPosition, Quaternion.identity);
                
                BoxCollider2D boxCollider = newZombie.AddComponent<BoxCollider2D>();
                newZombie.layer = 7;
                boxCollider.size = new Vector2(10f, 10f);
                Debug.Log(boxCollider.transform.position);
                
                SetLayerRecursive(newZombie, 10*(10-position.y));
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
