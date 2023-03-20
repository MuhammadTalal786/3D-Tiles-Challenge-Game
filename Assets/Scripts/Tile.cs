using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    public GameObject[] buttons;
    private int activeButtonIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            // Disable all buttons
            foreach (GameObject button in buttons)
            {
                button.SetActive(false);
            }

            // Increment the active button index
            activeButtonIndex++;

            // Enable the next button
            if (activeButtonIndex < buttons.Length)
            {
                buttons[activeButtonIndex].SetActive(true);
            }
        }
    }
}

