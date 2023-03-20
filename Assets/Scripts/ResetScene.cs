using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetScene : MonoBehaviour
{
	public void ResetSceneFunction()
	{
		SceneManager.LoadScene(0);
	}
}
