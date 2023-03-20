using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle4 : MonoBehaviour
{
	public Behaviour Canvas_D;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Canvas_D.enabled = !Canvas_D.enabled;
		}
	}
}
