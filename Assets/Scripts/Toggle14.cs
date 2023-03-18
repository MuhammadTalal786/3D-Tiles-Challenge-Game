using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle14 : MonoBehaviour
{
	public Behaviour Canvas_N;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			Canvas_N.enabled = !Canvas_N.enabled;
		}
	}
}
