using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllion : MonoBehaviour
{
	[SerializeField]
	private Transform[] lion;

	[SerializeField]
	private GameObject winText;

	public static bool youWin;

	void Start()
	{
		winText.SetActive(false);
		youWin = false;
	}

	void Update()
	{
		if (lion[0].rotation.z == 0 &&
			lion[1].rotation.z == 0 &&
			lion[2].rotation.z == 0 &&
			lion[3].rotation.z == 0 &&
			lion[4].rotation.z == 0 &&
			lion[5].rotation.z == 0 )
			
		{
			youWin = true;
			winText.SetActive(true);
		}
	}
}
