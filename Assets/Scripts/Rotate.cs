using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 dragOrigin;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = dragOrigin - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        
    }
}
