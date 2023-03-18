using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcomp : MonoBehaviour
{
    public GameObject Man_Full;

    public GameObject LevelComplete;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "levelcomplete")
            Man_Full.SetActive(false);
        LevelComplete.SetActive(true);
    }
}