using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject player;
    private Timer score;
    // Start is called before the first frame update
    void Start()
    {
       score = FindObjectOfType<Timer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject == player)
        {
            score.AddScore(100);
            Destroy(gameObject);
        }
    }
}
