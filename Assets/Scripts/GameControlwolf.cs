using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlwolf : MonoBehaviour
{
	[SerializeField]
	private Transform[] wolf;

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
		if (wolf[0].rotation.z == 0 &&
			wolf[1].rotation.z == 0 &&
			wolf[2].rotation.z == 0 &&
			wolf[3].rotation.z == 0 &&
			wolf[4].rotation.z == 0 &&
			wolf[5].rotation.z == 0)

		{
			youWin = true;
			winText.SetActive(true);
		}
	}
}
