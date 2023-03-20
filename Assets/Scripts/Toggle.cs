using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toggle : MonoBehaviour
{
    public Behaviour Canvas_A;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Canvas_A.enabled = !Canvas_A.enabled;
		}
	}
	
}
