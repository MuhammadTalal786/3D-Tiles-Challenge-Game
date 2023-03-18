using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlZebra : MonoBehaviour
{
	[SerializeField]
	private Transform[] zebra;

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
		if (zebra[0].rotation.z == 0 &&
			zebra[1].rotation.z == 0 &&
			zebra[2].rotation.z == 0 &&
			zebra[3].rotation.z == 0 &&
			zebra[4].rotation.z == 0 &&
			zebra[5].rotation.z == 0)

		{
			youWin = true;
			winText.SetActive(true);
		}
	}
}
