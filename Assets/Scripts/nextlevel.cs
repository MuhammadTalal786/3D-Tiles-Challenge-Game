using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
	public void ChangeScene()
	{
		SceneManager.LoadScene("Level 2");
	}
	public void ChangeScene2()
	{
		SceneManager.LoadScene("Level 3");
	}
}
  
