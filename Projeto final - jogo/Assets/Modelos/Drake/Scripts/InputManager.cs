using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    DrakeControls drakeControls;
    AnimatorManager animatorManager;
    PlayerLocomotion playerLocomotion;
 
    public Vector2 movementInput;

    public Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool correndo = false;
    public bool moving = false;

    public bool defending = false;
    public bool rolando = false;

    // NPC detection vars
    private bool interagindo = false;
    private bool raioInteracao = false;
    private GameObject triggeringNPC = null;

    // NPC text objectcs
    public GameObject interactionTooltip;
    public GameObject npcText;

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
            drakeControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            

            drakeControls.PlayerActions.SHIFT.performed += i => correndo = true;
            drakeControls.PlayerActions.SHIFT.canceled += i => correndo = false;

            drakeControls.PlayerActions.SHIELD.performed += i => defending = true;

            drakeControls.PlayerActions.DODGE.performed += i => rolando = true;

            drakeControls.PlayerActions.INTERACT.performed += i => interagindo = true;
            drakeControls.PlayerActions.INTERACT.canceled += i => interagindo = false;


        }
        drakeControls.Enable();
    }


    private void OnDisable()
    {

        drakeControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleSprintingInput();
        HandleMovementInput();
        HandleShieldInput();
        HandleDodgeInput();
        HandleInteractionInput();

    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.correndo);
        
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
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

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            raioInteracao = true;
            triggeringNPC = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            raioInteracao = false;
            triggeringNPC = null;
        }
    }

    private void HandleInteractionInput()
    {
        if (raioInteracao)
        {
            interactionTooltip.SetActive(true);

            if (interagindo)
            {
                npcText.SetActive(true);
            } else
            {
                npcText.SetActive(false);
            }
        } else {
            interactionTooltip.SetActive(false);
        }
    }
}
