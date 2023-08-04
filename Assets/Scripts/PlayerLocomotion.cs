using System.Collections;
using UnityEngine;

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
        if (isJumpLag) return;
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
        float jumpingVelocity = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
        Vector3 playerVelocity = moveDirection;
        playerVelocity.y = jumpingVelocity;
        playerRigidbody.AddForce(new Vector3(0, jumpingVelocity, 0), ForceMode.Impulse);
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        var movementVelocity = moveDirection * movementSpeed;
        movementVelocity.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = movementVelocity;
    }

    
    public void HandleRotation()
    {
        // If there is touch input, rotate the camera based on the touch delta position
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationSpeed = 1f; // Adjust this value to control rotation speed
                float cameraXInput = touch.deltaPosition.x * rotationSpeed;
                float cameraYInput = touch.deltaPosition.y * rotationSpeed;

                // Rotate the camera around the player
                Vector3 cameraRotation = cameraObject.rotation.eulerAngles;
                cameraRotation.x -= cameraYInput;
                cameraRotation.y += cameraXInput;
                cameraObject.rotation = Quaternion.Euler(cameraRotation);
            }
        }
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
            playerRigidbody.AddForce(-Vector3.up * fallingVelocty * inAirTimer);
        }

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, 1f, groundLayer))
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
