using UnityEngine;

public class SceneStateManager : MonoBehaviour
{
    private static string previousSceneName;
    private static Vector3 previousPosition;

    public static void SetPreviousSceneName(string sceneName)
    {
        previousSceneName = sceneName;
    }

    public static string GetPreviousSceneName()
    {
        return previousSceneName;
    }

    public static void SetPreviousPosition(Vector3 position)
    {
        previousPosition = position;
    }

    public static Vector3 GetPreviousPosition()
    {
        return previousPosition;
    }
}
