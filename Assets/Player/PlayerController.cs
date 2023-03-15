
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 2.0f;

    private CharacterController controller;
    private Camera playerCamera;
    private float moveFB, moveLR;
    private float rotX, rotY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Get input for movement and rotation
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the player horizontally
        transform.Rotate(0, rotX, 0);

        // Rotate the camera vertically
        playerCamera.transform.Rotate(-rotY, 0, 0);

        // Move the player forward/backward and left/right
        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        movement = transform.rotation * movement;
        controller.Move(movement * Time.deltaTime);
    }
}

