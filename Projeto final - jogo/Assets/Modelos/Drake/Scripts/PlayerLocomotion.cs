using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerManager playerManager;
    AnimatorManager animatorManager;
    InputManager inputManager;
    Vector3 moveDirection;
    Transform cameraObject;
    matar matar;
    public Rigidbody playerRigidBody;
    public float walkingSpeed = 3;
    public float sprintingSpeed = 6;
    public float rotationSpeed = 15;
    public bool isGrounded;
    public float inAirTimer;
    public float leapingVelocity;
    public float rayCastHeightOffSet = 0.5f;
    public float fallingVelocity;
    public LayerMask groundLayer;
    public bool correndo = false;


    private void Awake()
    {
        matar = GetComponent<matar>();
        animatorManager = GetComponent<AnimatorManager>();
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        //moveDirection.z = moveDirection.z * 2.9f;
        moveDirection.y = 0;
        if(correndo)
        {
            moveDirection = moveDirection * sprintingSpeed;
        }
        else
        {
            moveDirection = moveDirection * walkingSpeed;
        }


        Vector3 movementVelocity = moveDirection;
        playerRigidBody.velocity = movementVelocity;
    }

    public void HandleRotation()
    {

        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = playerRotation;
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();
        if (playerManager.isInteracting && !playerManager.isUsingRootMotion)
        {
            return;
        }
        HandleMovement();
        HandleRotation();
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        if (!isGrounded)
        {
            if (!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("caindo", true);
            }
            animatorManager.animator.SetBool("isUsingRootMotion", false);
            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidBody.AddForce(transform.forward * leapingVelocity);
            playerRigidBody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
        }
        if (Physics.SphereCast(rayCastOrigin, 0.01f, -Vector3.up, out hit,  groundLayer))
        {
            
            if (!isGrounded && !playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("pousando", true);
            }
            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void HandleDodge()
    {
        if (playerManager.isInteracting || !correndo)
            return;
        animatorManager.PlayTargetAnimation("rolamento", true, true);

    }

    public void HandleShield()
    {
        if (playerManager.isInteracting)
            return;
        animatorManager.PlayTargetAnimation("defendendo", true);
        matar.atacarEscudo();

    }

}
