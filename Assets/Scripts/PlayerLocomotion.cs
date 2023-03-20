using System.Collections;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;



public class PlayerLocomotion : MonoBehaviour
{
	private PlayerManager playerManager;
	private AnimatorManager animatorManager;
	private InputManager inputManager;
	private Transform cameraObject;
	private Vector3 moveDirection;
	private Vector3 targetDirection;
	private Rigidbody playerRigidbody;
	private GameManagement gameManagement;

	[Header("Falling")] 
	public float inAirTimer;
	public float leapingVelocity;
	public float fallingVelocty;
	public LayerMask groundLayer;
	public float rayCastHeightOffset = 0.5f;


	[Header("Movement Flags")] 
	public bool isGrounded;
	public bool isJumping;
	public bool isJumpLag = false;
	
	[Header("Movement Speeds")]
	[SerializeField] public float movementSpeed = 7f;
	[SerializeField] private float rotationSpeed = 15f;

	[Header("Jump Speeds")] 
	[SerializeField] private float jumpHeight = 3f;
	[SerializeField] private float gravityIntensity = -15f;
	[SerializeField] float jumpLag = 0.35f;


	private void Awake()
	{
		gameManagement = GetComponent<GameManagement>();
		playerManager = GetComponent<PlayerManager>();
		animatorManager = GetComponent<AnimatorManager>();
		inputManager = GetComponent<InputManager>();
		playerRigidbody = GetComponent<Rigidbody>();
		if (Camera.main is { }) cameraObject = Camera.main.transform;
	}

	public void HandleAllMovement()
	{
		HandleFallingAndLanding();
		if (playerManager.isInteracting) return;
		if (isJumpLag) return ;
		HandleMovement();
		HandleRotation();
	}

	public void HandleJumping()
	{
		if (isGrounded)
		{
			StartCoroutine(JumpCoroutine());
			animatorManager.animator.SetBool("isJumping", true);
			animatorManager.PlayTargetAnimation("Jump", false);
		}
	}

	private IEnumerator JumpCoroutine()
	{
		isJumpLag = true;
		playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.y);
		yield return new WaitForSecondsRealtime(jumpLag);
		isJumpLag = false;
		float jumpingVelocity = Mathf.Sqrt
			(-2 * gravityIntensity * jumpHeight);
		Vector3 playerVelocity = moveDirection;
		playerVelocity.y = jumpingVelocity;
		//playerRigidbody.velocity = playerVelocity;
		playerRigidbody.AddForce(new Vector3(0, jumpingVelocity, 0), ForceMode.Impulse);
	}

	private void HandleMovement()
	{
		//if (!isGrounded) return;
		moveDirection = cameraObject.forward * inputManager.verticalInput; 
		moveDirection += cameraObject.right * inputManager.horizontalInput;
		moveDirection.Normalize(); //normalize to a unit vector
		moveDirection.y = 0; //to prevent the player from moving straight up into the sky

		var movementVelocity = moveDirection * movementSpeed;
		movementVelocity.y = playerRigidbody.velocity.y;
		playerRigidbody.velocity = movementVelocity;
	}

	private void HandleRotation()
	{
		//if (isJumping) return;
		
		targetDirection = cameraObject.forward * inputManager.verticalInput;
		targetDirection += cameraObject.right * inputManager.horizontalInput;
		targetDirection.Normalize();
		targetDirection.y = 0; //to prevent player from rotating  in a an axis parallel to the plane
		
		//prevent the locking of rotation
		if (targetDirection == Vector3.zero)
			targetDirection = transform.forward;
			//Keep rotation at the position we are looking when we stop moving
		
		var targetRotation = Quaternion.LookRotation(targetDirection);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}

	private void HandleFallingAndLanding()
	{
		RaycastHit hit;
		Vector3 rayCastOrigin = transform.position;
		rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;
		if (!isGrounded && !isJumping)
		{
			if (!playerManager.isInteracting)
			{
				animatorManager.PlayTargetAnimation("Falling", true);
			}

			inAirTimer += Time.deltaTime;
			playerRigidbody.AddForce(transform.forward * leapingVelocity);
			playerRigidbody.AddForce(-Vector3.up * fallingVelocty * inAirTimer); //the longer you are in the air the quicker the player falls
		}

		if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit,1f, groundLayer))
		{
			if (!isGrounded && playerManager.isInteracting)
			{
				animatorManager.PlayTargetAnimation("Land", true);
			}

			inAirTimer = 0;
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
	}
}
