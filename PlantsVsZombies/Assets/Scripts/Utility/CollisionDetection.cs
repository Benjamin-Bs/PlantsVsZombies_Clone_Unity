using System.Linq;
using UnityEngine;

namespace Utility
{
    public class CollisionDetection
    {
        public static bool HasCollisionWithLayer(GameObject gameObject, int layer)
        {
            return FindCollisionWithLayer(gameObject, layer) != null;
        }

        public static GameObject FindCollisionWithLayer(GameObject gameObject, int layer)
        {
            if (gameObject == null) return null;
            BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
            Collider2D[] colliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0f);
        
            foreach (Collider2D col in colliders)
            {
                if (col.gameObject.layer == layer)
                {
                    if (col.gameObject.transform.position.z == gameObject.transform.position.z)
                    {
                        return col.gameObject;
                    }
                }
            }
            return null;
        }
    }
}