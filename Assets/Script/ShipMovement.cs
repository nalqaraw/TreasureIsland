using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Public variables
    public float moveSpeed = 5f; // Speed of movement
    public float rotateSpeed = 10f; // Speed of rotation

    // Private variables
    private Rigidbody rb; // Rigidbody component of ship
    private float movement; // Direction of movement
    private float rotation; // Direction of rotation

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Handle input for movement
        movement = Input.GetAxisRaw("Vertical");

        // Handle input for rotation
        rotation = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Move the ship forwards or backwards
        Vector3 movementVector = transform.forward * movement * moveSpeed;
        rb.AddForce(movementVector, ForceMode.VelocityChange);

        // Rotate the ship
        Quaternion turnRotation = Quaternion.Euler(0f, rotation * rotateSpeed, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
