using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlbike : MonoBehaviour
{
	[SerializeField]
	private Transform[] bike;

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
		if (bike[0].rotation.z == 0 &&
			bike[1].rotation.z == 0 &&
			bike[2].rotation.z == 0 &&
			bike[3].rotation.z == 0 &&
			bike[4].rotation.z == 0 &&
			bike[5].rotation.z == 0)

		{
			youWin = true;
			winText.SetActive(true);
		}
	}
}
