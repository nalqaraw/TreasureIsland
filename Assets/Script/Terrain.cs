using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Terrain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Get the contact point of the collision
        ContactPoint contact = collision.contacts[0];

        // Get the transform of the collided object
        Transform collidedObjectTransform = collision.gameObject.transform;

       

        // Print the position of the collided object
        Debug.Log("Collided object position: " + collidedObjectTransform.position);

        LoadScene("GameMode");
    }
}
