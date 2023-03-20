using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{

    public static spawnManager Instance;
   public GameObject[] spawnPoints;

    private void Awake()
    {
        Instance = this;
    }

}
