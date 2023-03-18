using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle7 : MonoBehaviour
{
	public Behaviour Canvas_G;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
		{
			Canvas_G.enabled = !Canvas_G.enabled;
		}
	}
}
