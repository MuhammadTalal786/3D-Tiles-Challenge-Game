using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle11 : MonoBehaviour
{
	public Behaviour Canvas_K;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			Canvas_K.enabled = !Canvas_K.enabled;
		}
	}
}
