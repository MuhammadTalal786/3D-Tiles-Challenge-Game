using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private Transform cameraPivot; //The object the camera pivot use
    [SerializeField] private LayerMask collisionLayers; //The layers we want the camera to collide with
    private Transform targetTransform; //The object the camera uses to pivot
    private Transform cameraTransform; //the transform of the actual camera object in the scene
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;
    
    [SerializeField] private float cameraFollowSpeed = 0.2f;
    [SerializeField] private float cameraLookSpeed = 2;
    [SerializeField] private float cameraCollisionRadius = 2f;
    [SerializeField] private float cameraCollisionOffset = 0.2f; //How much the camera will jump off of objects its colliding with
    [SerializeField] private float minimumCollisionOffset = 0.2f;
    
    private float lookAngle; //Camera looking up and down
    private float pivotAngle; //Camera looking left and right
    [SerializeField] private float minPivotAngle = -35f;
    [SerializeField] private float maxPivotAngle = 35f;
    private float defaultPosition;

    
    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        if (Camera.main is { }) cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        lookAngle += inputManager.cameraXInput * cameraLookSpeed;
        pivotAngle -= inputManager.cameraYInput * cameraLookSpeed;
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        transform.rotation = Quaternion.Euler(0, lookAngle, 0);
        cameraPivot.localRotation = Quaternion.Euler(pivotAngle, 0, 0);
    }

    private void HandleCameraCollisions()
    {
        var targetPosition = defaultPosition;
        var direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();
        
        if(Physics.SphereCast
            (cameraPivot.transform.position, cameraCollisionRadius, direction, out var hit, Mathf.Abs(targetPosition), collisionLayers))
        {
            var distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition = -(distance - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
        {
            targetPosition -= minimumCollisionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
    
}
