using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle10 : MonoBehaviour
{
	public Behaviour Canvas_J;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Canvas_J.enabled = !Canvas_J.enabled;
		}
	}
}
