using UnityEngine;
using UnityEngine.SceneManagement;


public class InputManager : MonoBehaviour
{

	private PlayerControls playerControls;
	private AnimatorManager animatorManager;
	private PlayerLocomotion playerLocomotion;
	private GameManagement gameManagement;
	

	private Vector2 movementInput;
	private Vector2 cameraInput;
	

	public float cameraXInput;
	public float cameraYInput;

	public float verticalInput;
	public float horizontalInput;


	
	private float moveAmount;

	public bool jumpInput;

	private void Awake()
	{
		animatorManager = GetComponent<AnimatorManager>();
		playerLocomotion = GetComponent<PlayerLocomotion>();
		gameManagement = GetComponent<GameManagement>();
	}

	private void OnEnable()
	{
		if (playerControls == null)
		{
			playerControls = new PlayerControls();
			playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
			playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
			playerControls.PlayerActions.Jump.performed += i => jumpInput = true;
		}
		playerControls.Enable();
	}

	private void OnDisable()
	{
		playerControls.Disable();
	}

	public void HandleAllInputs()
	{
		HandleMovement();
		HandleJumpingInput();
	}
	
	private void HandleMovement()
	{

		verticalInput = movementInput.y;
		horizontalInput = movementInput.x;
		cameraXInput = cameraInput.x;
		cameraYInput = cameraInput.y;
		moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
		animatorManager.UpdateAnimatorValues(0, moveAmount);
	}

	private void HandleJumpingInput()
	{
		if (jumpInput && !playerLocomotion.isJumping)
		{
			jumpInput = false;
			playerLocomotion.HandleJumping();
			
		}
	}
	
	
}
