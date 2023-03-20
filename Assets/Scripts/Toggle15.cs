using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle15 : MonoBehaviour
{
	public Behaviour Canvas_O;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			Canvas_O.enabled = !Canvas_O.enabled;
		}
	}
}
