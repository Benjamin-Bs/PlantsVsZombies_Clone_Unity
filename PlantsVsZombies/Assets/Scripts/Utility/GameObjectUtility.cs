using System;
using UnityEngine;

namespace Utility
{
    public class GameObjectUtility
    {
        public static GameObject findChild(GameObject gameObject, String name)
        {
            Transform childTransform = gameObject.transform.Find(name);
            if (childTransform != null) {
                return childTransform.gameObject;
            }
            return null;
        }
        
        public static void SetRecursive(GameObject obj, Action<SpriteRenderer> function)
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
}