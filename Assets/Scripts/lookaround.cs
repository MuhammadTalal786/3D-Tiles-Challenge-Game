using UnityEngine;
using UnityEngine.InputSystem;

public class lookaround : MonoBehaviour
{
    public float sensitivity = 100f;
    private Vector2 touchDelta;
    [SerializeField] private InputAction touchAction;

    private void OnEnable()
    {
        touchAction.Enable();
    }

    private void OnDisable()
    {
        touchAction.Disable();
    }

    private void Update()
    {
        touchDelta = touchAction.ReadValue<Vector2>();
        touchDelta *= sensitivity * Time.deltaTime;
        transform.Rotate(-touchDelta.y, touchDelta.x, 0f);
    }
}

