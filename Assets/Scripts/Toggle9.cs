using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle9 : MonoBehaviour
{
	public Behaviour Canvas_I;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			Canvas_I.enabled = !Canvas_I.enabled;
		}
	}
}
