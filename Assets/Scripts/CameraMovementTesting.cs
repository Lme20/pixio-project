using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class CameraMovementTesting : MonoBehaviour
{
    public float moveSpeed = 150.0f;
    private Vector3 moveVector;
    public float rotationSpeed = 3f;

    void Start()
    {
        moveVector = new Vector3(0, 0, 0);
    }

    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        // Handle Mouse Rotation
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotationAmount = new Vector3(0f, mouseX * rotationSpeed, 0f);
        transform.Rotate(rotationAmount);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position += moveSpeed * moveVector * Time.deltaTime;
        }
    }
}
