using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.CompareTag("Destroy") && collision.gameObject.name == ("Sphere(Clone)")
            | collision.gameObject.name == ("Cube(Clone)") | collision.gameObject.name == ("Capsule(Clone)") |
            collision.gameObject.name == ("Diamond(Clone)") | collision.gameObject.name == ("DoublePoints(Clone)"))
        {
            Destroy(collision.gameObject);
        }
    }
}
