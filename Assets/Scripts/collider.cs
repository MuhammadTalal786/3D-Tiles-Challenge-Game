using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class collider : MonoBehaviour
{

    public GameObject button;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            button.SetActive(true);
            HideAllButtons();
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            button.SetActive(true);
            HideAllButtons();
        }
    }

        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                button.SetActive(false);

            }
        }


        void HideAllButtons()
        {

            GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
            foreach (GameObject btn in buttons)
            {
                if (btn != button)
                    btn.SetActive(false);
            }
        }
    }

