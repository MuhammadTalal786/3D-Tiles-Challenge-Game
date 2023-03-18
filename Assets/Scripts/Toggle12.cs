using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle12 : MonoBehaviour
{
	public Behaviour Canvas_L;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			Canvas_L.enabled = !Canvas_L.enabled;
		}
	}
}
