using UnityEngine;

public class PlayerPositionStore : MonoBehaviour
{
    private static Vector3 storedPosition;

    private void Awake()
    {
        // If a stored position exists, move the player to that position
        if (storedPosition != Vector3.zero)
        {
            transform.position = storedPosition;
            storedPosition = Vector3.zero; // Reset the stored position
        }
    }

    public static void StorePosition(Vector3 position)
    {
        storedPosition = position;
    }
}
