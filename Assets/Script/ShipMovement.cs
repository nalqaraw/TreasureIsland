using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Public variables
    public float moveSpeed = 10f;   // speed of the ship
    public float turnSpeed = 100f;  // rotation speed of the ship
    public float buoyancy = 2f;     // how much the ship floats on the water
    public float waterLevel = 0f;   // y-coordinate of the water level
    public float brakeStrength = 10f;

    // Private variables
    private Rigidbody rb; // Rigidbody component of ship

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed;
        rb.AddForce(moveDirection, ForceMode.Acceleration);

        if (moveDirection.magnitude == 0)
        {
            rb.AddForce(-rb.velocity.normalized * brakeStrength);
        }

        // rotate the ship left or right
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
