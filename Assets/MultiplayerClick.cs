using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerClick : MonoBehaviour
{
    public void onMultiplayerSceneOpen()
    {
        SceneManager.LoadScene(33);
    }
}
