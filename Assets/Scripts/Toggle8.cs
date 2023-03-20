using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle8 : MonoBehaviour
{
	public Behaviour Canvas_H;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			Canvas_H.enabled = !Canvas_H.enabled;
		}
	}
}
