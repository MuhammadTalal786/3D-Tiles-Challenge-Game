using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidebutton : MonoBehaviour
{
	public GameObject Man_Full;
	public GameObject hideUI;


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "hide")
			Man_Full.SetActive(false);
		hideUI.SetActive(true);
	}

}
