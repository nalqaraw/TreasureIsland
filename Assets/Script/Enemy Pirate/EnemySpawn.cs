using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        Instantiate(enemy, new Vector3(-130,12,-15), Quaternion.identity);
        Instantiate(enemy, new Vector3(-120,12,-10), Quaternion.identity);
        Instantiate(enemy, new Vector3(-125,12,-20), Quaternion.identity);
        Instantiate(enemy, new Vector3(-133,12,-25), Quaternion.identity);
        Instantiate(enemy, new Vector3(-110,12,-5), Quaternion.identity);
    }

}
