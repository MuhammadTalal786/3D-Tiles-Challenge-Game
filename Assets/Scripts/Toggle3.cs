using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle3 : MonoBehaviour
{
	public Behaviour Canvas_C;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			Canvas_C.enabled = !Canvas_C.enabled;
		}
	}
}
