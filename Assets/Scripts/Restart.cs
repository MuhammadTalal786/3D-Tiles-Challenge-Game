using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    private int sceneToContinue;

    public void RestartScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void RestartScene2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void RestartScene3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void RestartScene4()
    {
        SceneManager.LoadScene("Level 4");
    }
}
