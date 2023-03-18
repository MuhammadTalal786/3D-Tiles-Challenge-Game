using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle5 : MonoBehaviour
{
	public Behaviour Canvas_E;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			Canvas_E.enabled = !Canvas_E.enabled;
		}
	}
}
