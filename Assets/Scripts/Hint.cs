using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hint : MonoBehaviour
{
	private int sceneToContinue;
	public void ChangeScene()
	{
		SceneManager.LoadScene("level 1 hint elephant");
	}

	public void ChangeScene2()
	{
		SceneManager.LoadScene("level 1 hint lion");
	}

	public void ChangeScene3()
	{
		SceneManager.LoadScene("level 1 hint wolf");
	}

	public void ChangeScene4()
	{
		SceneManager.LoadScene("level 1 hint zebra");
	}

	public void ChangeScene5()
	{
		SceneManager.LoadScene("level 1 hint car bike");
	}

	public void ChangeScene6()
	{
		SceneManager.LoadScene("level 1 hint bike");
	}

	public void ChangeScene7()
	{
		SceneManager.LoadScene("level 1 hint bike2");
	}

	public void ChangeScene8()
	{
		SceneManager.LoadScene("level 1 hint car");
	}

	public void ChangeScene9()
	{
		SceneManager.LoadScene("level 1 hint cat");
	}

	public void ChangeScene10()
	{
		SceneManager.LoadScene("level 1 hint dog");
	}

	public void ChangeScene11()
	{
		SceneManager.LoadScene("level 1 hint nature");
	}

	public void ChangeScene12()
	{
		SceneManager.LoadScene("level 1 hint owl");
	}

	public void ChangeScene13()
	{
		SceneManager.LoadScene("level 1 hint parrot");
	}

	public void ChangeScene14()
	{
		SceneManager.LoadScene("level 1 hint tiger");
	}
	public void ChangeScene30()
	{
		SceneManager.LoadScene("level 1 hint p");
	}
	public void Continue()
	{
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");

		if (sceneToContinue != 0)
			SceneManager.LoadScene(sceneToContinue);
		else
			return;
    }
	public void ChangeScene15()
	{
		SceneManager.LoadScene("level 2 hint 1");
	}

	public void ChangeScene16()
	{
		SceneManager.LoadScene("level 2 hint 2");
	}

	public void ChangeScene17()
	{
		SceneManager.LoadScene("level 2 hint 3");
	}

	public void ChangeScene18()
	{
		SceneManager.LoadScene("level 2 hint 4");
	}

	public void ChangeScene19()
	{
		SceneManager.LoadScene("level 2 hint 5");
	}

	public void ChangeScene20()
	{
		SceneManager.LoadScene("level 2 hint 6");
	}

	public void ChangeScene21()
	{
		SceneManager.LoadScene("level 2 hint 7");
	}

	public void ChangeScene22()
	{
		SceneManager.LoadScene("level 2 hint 8");
	}

	public void ChangeScene23()
	{
		SceneManager.LoadScene("level 2 hint 9");
	}

	public void ChangeScene24()
	{
		SceneManager.LoadScene("level 2 hint 10");
	}

	public void ChangeScene25()
	{
		SceneManager.LoadScene("level 2 hint 11");
	}

	public void ChangeScene26()
	{
		SceneManager.LoadScene("level 2 hint 12");
	}

	public void ChangeScene27()
	{
		SceneManager.LoadScene("level 2 hint 13");
	}

	public void ChangeScene28()
	{
		SceneManager.LoadScene("level 2 hint 14");
	}
     	public void ChangeScene29()
	{
		SceneManager.LoadScene("level 3 hint 1");
	}
	public void ChangeScene31()
	{
		SceneManager.LoadScene("level 3 hint 1");
	}
	public void ChangeScene32()
	{
		SceneManager.LoadScene("level 3 hint 2");
	}
	public void ChangeScene33()
	{
		SceneManager.LoadScene("level 3 hint 3");
	}
	public void ChangeScene34()
	{
		SceneManager.LoadScene("level 3 hint 4");
	}
	public void ChangeScene35()
	{
		SceneManager.LoadScene("level 3 hint 5");
	}
	public void ChangeScene36()
	{
		SceneManager.LoadScene("level 3 hint 6");
	}
	public void ChangeScene37()
	{
		SceneManager.LoadScene("level 3 hint 7");
	}
	public void ChangeScene38()
	{
		SceneManager.LoadScene("level 3 hint 8");
	}
	public void ChangeScene39()
	{
		SceneManager.LoadScene("level 3 hint 9");
	}
	public void ChangeScene40()
	{
		SceneManager.LoadScene("level 3 hint 10");
	}
	public void ChangeScene41()
	{
		SceneManager.LoadScene("level 3 hint 11");
	}
	public void ChangeScene42()
	{
		SceneManager.LoadScene("level 3 hint 12");
	}
	public void ChangeScene43()
	{
		SceneManager.LoadScene("level 3 hint 13");
	}
	public void ChangeScene44()
	{
		SceneManager.LoadScene("level 3 hint 14");
	}
	public void Back()
{
	SceneManager.LoadScene("Level 1");
		
	}
	public void Back2()
	{
		SceneManager.LoadScene("Level 2");
	}
      public void Back3()
	{
		SceneManager.LoadScene("Level 3");
	}

}