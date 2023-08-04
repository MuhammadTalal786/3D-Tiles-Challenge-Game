using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
	[SerializeField]
	private Transform[] animal;

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
		if (animal[0].rotation.z == 0 &&
			animal[1].rotation.z == 0 &&
			animal[2].rotation.z == 0 &&
			animal[3].rotation.z == 0 &&
			animal[4].rotation.z == 0 &&
			animal[5].rotation.z == 0)
		{
			youWin = true;
			winText.SetActive(true);
		}
	}
}