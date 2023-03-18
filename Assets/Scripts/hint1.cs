using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hint1 : MonoBehaviour
{
	public GameObject uiObject;
	void Start()
	{
		uiObject.SetActive(false);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			uiObject.SetActive(true);
			StartCoroutine("Waitforsec");
		}
	}
	IEnumerator Waitforsec()
	{
		yield return new WaitForSeconds(1);
		Destroy(uiObject);
		Destroy(gameObject);
	}
	private int sceneToContinue;
	public void ChangeScene()
	{
		SceneManager.LoadScene("level 1 hint elephant");
	}

	public void ChangeScene2()
	{
		SceneManager.LoadScene("level 1 hint lion");
	}
	public void Continue()
	{
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");

		if (sceneToContinue != 0)
			SceneManager.LoadScene(sceneToContinue);
		else
			return;
	}

	public void Back()
	{
		SceneManager.LoadScene("Level 1");
	}

}
