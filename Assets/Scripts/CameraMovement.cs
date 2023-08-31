using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;

    void Update()
    {
        // Handle Keyboard Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //float leftInput = Input.GetAxis("Left");
        //float rightInput = Input.GetAxis("Right");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime);

        // Handle Mouse Rotation
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotationAmount = new Vector3(0f, mouseX * rotationSpeed, 0f);
        transform.Rotate(rotationAmount);
    }
}

