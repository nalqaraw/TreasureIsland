using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     public Transform player;
    public float distance = 10f;
    public float rotationAmount = 20f;
    public float cameraHeight = 2f;
    public float rotationSpeed = 10f; // adjust as needed

    private bool isRotating = false;
    private Quaternion targetRotation;

    void Update()
    {
        // Rotate player left or right when arrow keys are pressed
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
        {
            targetRotation = player.rotation * Quaternion.AngleAxis(rotationAmount, Vector3.up);
            StartCoroutine(RotatePlayer());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating)
        {
            targetRotation = player.rotation * Quaternion.AngleAxis(-rotationAmount, Vector3.up);
            StartCoroutine(RotatePlayer());
        }

        // Move camera to stay a fixed distance from player at a height of cameraHeight
        Vector3 playerPos = player.position + Vector3.up * cameraHeight;
        transform.position = playerPos - player.forward * distance;
        transform.LookAt(playerPos);
    }

    IEnumerator RotatePlayer()
    {
        isRotating = true;
        float t = 0f;
        Quaternion startRotation = player.rotation;

        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed;
            player.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        isRotating = false;
    }
}
