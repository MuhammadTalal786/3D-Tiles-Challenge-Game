using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
	public GameObject Man_Full;

	public GameObject GameOverUI;

	

	 void OnTriggerEnter(Collider other)
	{
		if (other.tag == "BreakGlass")
			Man_Full.SetActive(false);
			GameOverUI.SetActive(true);
	}
}
