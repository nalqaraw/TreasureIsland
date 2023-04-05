using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealthBar : MonoBehaviour
{
    public GameObject player;
    public Slider slider;

    void Start()
    {
        // Set the initial value of the slider to full health
        slider.value = player.GetComponent<ShipMovement>().health;
    }

    void Update()
    {
        // Update the slider value based on the player's current health
        slider.value = player.GetComponent<ShipMovement>().health;
    }
 }
