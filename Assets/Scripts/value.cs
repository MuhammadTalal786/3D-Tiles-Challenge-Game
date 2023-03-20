using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class value : MonoBehaviour
{
    public Vector3 CubePosition;
    void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag=="cube")
		{
            CubePosition = other.gameObject.transform.position;
        }
        if (other.gameObject.tag == "plane")
        {
            transform.position = CubePosition;
        }
    }

}


