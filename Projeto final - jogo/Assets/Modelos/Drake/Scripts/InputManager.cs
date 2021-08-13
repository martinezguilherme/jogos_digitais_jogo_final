using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    DrakeControls drakeControls;
    AnimatorManager animatorManager;
    PlayerLocomotion playerLocomotion;
    public Vector2 movementInput;
    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool correndo = false;
    public bool moving = false;

    public bool defending = false;
    public bool rolando = false;


    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        if (movementInput != new Vector2(0.0f, 0.0f) && correndo)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }

    private void OnEnable()
    {
        if(drakeControls == null)
        {
            drakeControls = new DrakeControls();

            drakeControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            drakeControls.PlayerActions.SHIFT.performed += i => correndo = true;
            drakeControls.PlayerActions.SHIFT.canceled += i => correndo = false;

            drakeControls.PlayerActions.SHIELD.performed += i => defending = true;

            drakeControls.PlayerActions.DODGE.performed += i => rolando = true;


        }
        drakeControls.Enable();
    }


    private void OnDisable()
    {

        drakeControls.Disable();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.correndo);
    }

    public void HandleAllInputs()
    {
        HandleSprintingInput();
        HandleMovementInput();
        HandleShieldInput();
        HandleDodgeInput();
    }

    private void HandleSprintingInput()
    {
        if (moving)
        {
            playerLocomotion.correndo = true;
        }
        else
        {
            playerLocomotion.correndo = false;
        }
    }

    private void HandleDodgeInput()
    {
        if (rolando)
        {
            rolando = false;
            playerLocomotion.HandleDodge();
        }
    }

    private void HandleShieldInput()
    {
        if (defending)
        {
            defending = false;
            playerLocomotion.HandleShield();
        }
    }

}
