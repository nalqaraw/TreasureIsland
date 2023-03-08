using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     public GameObject pirate;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - pirate.transform.position;
    }

    void LateUpdate()
    {
        transform.position = pirate.transform.position + offset;
    }
}
