using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle2 : MonoBehaviour
{
	public Behaviour Canvas_B;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Canvas_B.enabled = !Canvas_B.enabled;
		}
	}
}
