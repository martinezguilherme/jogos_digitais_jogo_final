// GENERATED AUTOMATICALLY FROM 'Assets/Drake Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DrakeControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DrakeControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Drake Controls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""345a8894-dc8d-43a4-8c1e-5cf949855229"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e00715ea-fa6e-469f-8326-ba7f8fb71814"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0a16a2d2-ec56-4a6f-a1b1-c2575aeb0016"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""068d8f95-042d-42d7-8dd6-f802dc1d9917"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0867644c-54f1-46b5-9bd6-813c61caee1b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7ebfdf02-a4b3-4fc4-a2e6-4571f01f17d5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e6a0b3b2-9192-4360-a799-b5125f9c6b4e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""a6460753-1394-4e77-822b-99a12a73cd5b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f6e92312-7b9e-4216-b245-946d0b31fb1d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""068ebed1-f950-41e4-970a-4c0d7916aa6e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d4f3215c-8e8d-475c-9771-d0a12a1e47c3"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a5c3472c-9ccf-4c1b-ae3d-4a1a73542598"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player Actions"",
            ""id"": ""73aaf4df-de51-4369-a7c9-9d93eea55de1"",
            ""actions"": [
                {
                    ""name"": ""SHIFT"",
                    ""type"": ""Button"",
                    ""id"": ""4e11b1a2-4726-4268-a7ed-d2440f14d7d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SHIELD"",
                    ""type"": ""Button"",
                    ""id"": ""506927df-1d7b-4191-b1c6-1a5bf8bae6df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DODGE"",
                    ""type"": ""Button"",
                    ""id"": ""ab234676-7cf1-4522-a127-3a14e66f128c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2244eaf8-4c76-486a-9a7c-f8c5b25197f4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SHIFT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""504b37ed-a3c8-4ac3-a092-2eade4cc55bf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SHIELD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""655b7a15-4b4f-4ac1-b043-78b74a44fba1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DODGE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        // Player Actions
        m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
        m_PlayerActions_SHIFT = m_PlayerActions.FindAction("SHIFT", throwIfNotFound: true);
        m_PlayerActions_SHIELD = m_PlayerActions.FindAction("SHIELD", throwIfNotFound: true);
        m_PlayerActions_DODGE = m_PlayerActions.FindAction("DODGE", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    public struct PlayerMovementActions
    {
        private @DrakeControls m_Wrapper;
        public PlayerMovementActions(@DrakeControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Actions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_SHIFT;
    private readonly InputAction m_PlayerActions_SHIELD;
    private readonly InputAction m_PlayerActions_DODGE;
    public struct PlayerActionsActions
    {
        private @DrakeControls m_Wrapper;
        public PlayerActionsActions(@DrakeControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SHIFT => m_Wrapper.m_PlayerActions_SHIFT;
        public InputAction @SHIELD => m_Wrapper.m_PlayerActions_SHIELD;
        public InputAction @DODGE => m_Wrapper.m_PlayerActions_DODGE;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @SHIFT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSHIFT;
                @SHIFT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSHIFT;
                @SHIFT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSHIFT;
                @SHIELD.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSHIELD;
                @SHIELD.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSHIELD;
                @SHIELD.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnSHIELD;
                @DODGE.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDODGE;
                @DODGE.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDODGE;
                @DODGE.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnDODGE;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SHIFT.started += instance.OnSHIFT;
                @SHIFT.performed += instance.OnSHIFT;
                @SHIFT.canceled += instance.OnSHIFT;
                @SHIELD.started += instance.OnSHIELD;
                @SHIELD.performed += instance.OnSHIELD;
                @SHIELD.canceled += instance.OnSHIELD;
                @DODGE.started += instance.OnDODGE;
                @DODGE.performed += instance.OnDODGE;
                @DODGE.canceled += instance.OnDODGE;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnSHIFT(InputAction.CallbackContext context);
        void OnSHIELD(InputAction.CallbackContext context);
        void OnDODGE(InputAction.CallbackContext context);
    }
}
