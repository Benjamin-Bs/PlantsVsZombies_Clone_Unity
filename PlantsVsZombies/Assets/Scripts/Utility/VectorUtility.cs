using UnityEngine;

namespace Utility
{
    public class VectorUtility
    {

        public static void setX(GameObject vectorObject, float x)
        {
            Vector3 vector3 = vectorObject.transform.position;
            vector3.x = x;
            vectorObject.transform.position = vector3;
        }
        
        public static void setY(GameObject vectorObject, float y)
        {
            Vector3 vector3 = vectorObject.transform.position;
            vector3.y = y;
            vectorObject.transform.position = vector3;
        }
        
        public static void setZ(GameObject vectorObject, float z)
        {
            Vector3 vector3 = vectorObject.transform.position;
            vector3.z = z;
            vectorObject.transform.position = vector3;
        }


    }
}