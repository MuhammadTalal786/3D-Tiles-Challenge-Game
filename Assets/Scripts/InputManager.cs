using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public FixedJoystick joystick;
    public float touchSensitivity = 0.1f;
    private AnimatorManager animatorManager;
    private PlayerLocomotion playerLocomotion;
    private GameManagement gameManagement;

    private Vector2 movementInput;
    private Vector2 cameraInput;

    public float cameraXInput;
    public float cameraYInput;

    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        gameManagement = GetComponent<GameManagement>();
    }

    private void Update()
    {
        HandleAllInputs();
    }

    public void HandleAllInputs()
    {
        HandleMovement();
        HandleCameraRotation();
        HandleJumpingInput();
    }

    private void HandleMovement()
    {
        verticalInput = joystick.Vertical;
        horizontalInput = joystick.Horizontal;
        float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleCameraRotation()
    {
        // Check for touch input and rotate the camera based on the touch delta position
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                cameraXInput = touch.deltaPosition.x * touchSensitivity;
                cameraYInput = touch.deltaPosition.y * touchSensitivity;
                // Pass the camera rotation inputs to the PlayerLocomotion script
                playerLocomotion.HandleCameraRotation(cameraXInput, cameraYInput);
            }
        }
    }

    private void HandleJumpingInput()
    {
        if (Input.GetButtonDown("Jump") && !playerLocomotion.isJumping)
        {
            playerLocomotion.HandleJumping();
        }
    }
}
