using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.LookAt(transform.position + direction);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<ShipMovement>().health -= 1f;
        }
    }
}
