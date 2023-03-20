using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class valuestore : MonoBehaviour
{
	
	public Vector3 CubePosition;


	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "cube")
		{
			CubePosition = other.gameObject.transform.position;
		}
		if (other.gameObject.tag == "plane")
		{
				transform.position = CubePosition;
			}
	}
	public void GoBack()
	{
		transform.position = CubePosition;
	}
}