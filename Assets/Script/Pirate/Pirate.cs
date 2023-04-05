using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    // Public variables
    public float moveSpeed = 5f; // Speed of movement
    public float rotateSpeed = 10f; // Speed of rotation
    public GameObject swordPrefab; // Prefab for sword
    public Transform attackPoint; // Point where sword is attacked
    public float attackRange = 0.5f; // Range of sword attack
    public int attackDamage = 10; // Amount of damage inflicted by sword
    public int maxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player

    // Private variables
    private Rigidbody rb; // Rigidbody component of player
    private Animator anim; // Animator component of player
    private Vector3 movement; // Direction of movement
    private Quaternion rotation; // Rotation of the player

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Handle input for movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal, 0, vertical);

        // Handle input for attacking when space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
            Attack();
        }

        // Calculate rotation of player based on movement direction
        if (movement != Vector3.zero)
        {
            rotation = Quaternion.LookRotation(movement);
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotate the player
        rb.MoveRotation(Quaternion.Lerp(rb.rotation, rotation, rotateSpeed * Time.fixedDeltaTime));
    }

    // Attack function
    void Attack()
    {
        // Play attack animation
        anim.SetTrigger("Attack");

        // Detect enemies in attack range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange);

        // Inflict damage on enemies
        foreach (Collider enemy in hitEnemies)
        {
            // Check if enemy is a dolphin
            if (enemy.CompareTag("Dolphin"))
            {
                // enemy.GetComponent<Dolphin>().TakeDamage(attackDamage);
            }
        }
    }

    // Take damage function
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Die function
    void Die()
    {
        // Code for when the player dies goes here
    }
}
