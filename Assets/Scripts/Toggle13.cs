using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle13 : MonoBehaviour
{
	public Behaviour Canvas_M;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			Canvas_M.enabled = !Canvas_M.enabled;
		}
	}
}
