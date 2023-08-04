using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private Vector3 cubePosition;

    private void Awake()
    {
        // Check if an instance of GameManager already exists
        if (instance != null)
        {
            // Destroy this GameManager to ensure only one instance is active
            Destroy(gameObject);
            return;
        }

        // Set this instance as the active GameManager
        instance = this;

        // Mark this GameObject to not be destroyed when loading new scenes
        DontDestroyOnLoad(gameObject);

        // Initialize any other game manager-related code here
    }

    // Store the cube position
    public void SetCubePosition(Vector3 position)
    {
        cubePosition = position;
    }

    // Retrieve the cube position
    public Vector3 GetCubePosition()
    {
        return cubePosition;
    }

    // Other GameManager code...
}
