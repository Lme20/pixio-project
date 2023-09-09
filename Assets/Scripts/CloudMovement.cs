using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0);
    public float speed = 1.0f;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x > 100)  // Set this based on world boundaries
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);  // Reset position
        }
    }
}


