using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle6 : MonoBehaviour
{
	public Behaviour Canvas_F;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Y))
		{
			Canvas_F.enabled = !Canvas_F.enabled;
		}
	}
}
