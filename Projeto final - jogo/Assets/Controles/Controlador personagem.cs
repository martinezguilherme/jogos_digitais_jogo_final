// GENERATED AUTOMATICALLY FROM 'Assets/Controles/Controlador personagem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controladorpersonagem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controladorpersonagem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlador personagem"",
    ""maps"": [
        {
            ""name"": ""Personagem"",
            ""id"": ""ff9ae1f2-308f-4632-8ddc-525173d5beb6"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6cb1c3f3-489e-46c4-b7df-7771a191e6ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Correr"",
                    ""type"": ""Button"",
                    ""id"": ""b884987d-a080-4c0a-8e75-58acb398a968"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Atacar"",
                    ""type"": ""Button"",
                    ""id"": ""cdb9e8ca-7933-4e6f-9049-77f195b212bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Equipar espada"",
                    ""type"": ""Button"",
                    ""id"": ""b7102368-1fde-4805-95fa-3efbc6ab4a0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Equipar besta"",
                    ""type"": ""Button"",
                    ""id"": ""f807a080-0fa0-4c19-aaa2-5c7d9cbd6009"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""56565741-a3f8-44ae-a9e7-633876f7cac4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Interagir"",
                    ""type"": ""Button"",
                    ""id"": ""fa962541-0a44-4a72-aff4-9b2b55fe27cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a6475064-109e-4b53-b72a-75482861356f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""80181672-7945-4a4a-943c-7c90f881a4d3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""746d7b82-0f51-4df9-b0f4-f6f71acf6c90"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cfab6734-95dd-418c-b1a9-790088adc10c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b32b7d52-79fa-48b6-bf1e-bf27b9920e23"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5098e396-3b30-4005-8bf2-ae220818967c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Correr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b7a3b8d-df5d-41ad-a2fb-52bf322543a5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Atacar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3faacbfa-533f-44ab-8757-55971d082169"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equipar espada"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7597554d-9ca3-43ce-95c3-72be1d6dc601"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equipar besta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb380d60-615a-47b8-bc4c-9611213fe53c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""575a0728-5d5d-4725-9107-094b1103bde9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interagir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Personagem
        m_Personagem = asset.FindActionMap("Personagem", throwIfNotFound: true);
        m_Personagem_Mover = m_Personagem.FindAction("Mover", throwIfNotFound: true);
        m_Personagem_Correr = m_Personagem.FindAction("Correr", throwIfNotFound: true);
        m_Personagem_Atacar = m_Personagem.FindAction("Atacar", throwIfNotFound: true);
        m_Personagem_Equiparespada = m_Personagem.FindAction("Equipar espada", throwIfNotFound: true);
        m_Personagem_Equiparbesta = m_Personagem.FindAction("Equipar besta", throwIfNotFound: true);
        m_Personagem_Camera = m_Personagem.FindAction("Camera", throwIfNotFound: true);
        m_Personagem_Interagir = m_Personagem.FindAction("Interagir", throwIfNotFound: true);
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

    // Personagem
    private readonly InputActionMap m_Personagem;
    private IPersonagemActions m_PersonagemActionsCallbackInterface;
    private readonly InputAction m_Personagem_Mover;
    private readonly InputAction m_Personagem_Correr;
    private readonly InputAction m_Personagem_Atacar;
    private readonly InputAction m_Personagem_Equiparespada;
    private readonly InputAction m_Personagem_Equiparbesta;
    private readonly InputAction m_Personagem_Camera;
    private readonly InputAction m_Personagem_Interagir;
    public struct PersonagemActions
    {
        private @Controladorpersonagem m_Wrapper;
        public PersonagemActions(@Controladorpersonagem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_Personagem_Mover;
        public InputAction @Correr => m_Wrapper.m_Personagem_Correr;
        public InputAction @Atacar => m_Wrapper.m_Personagem_Atacar;
        public InputAction @Equiparespada => m_Wrapper.m_Personagem_Equiparespada;
        public InputAction @Equiparbesta => m_Wrapper.m_Personagem_Equiparbesta;
        public InputAction @Camera => m_Wrapper.m_Personagem_Camera;
        public InputAction @Interagir => m_Wrapper.m_Personagem_Interagir;
        public InputActionMap Get() { return m_Wrapper.m_Personagem; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PersonagemActions set) { return set.Get(); }
        public void SetCallbacks(IPersonagemActions instance)
        {
            if (m_Wrapper.m_PersonagemActionsCallbackInterface != null)
            {
                @Mover.started -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnMover;
                @Mover.performed -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnMover;
                @Mover.canceled -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnMover;
                @Correr.started -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnCorrer;
                @Correr.performed -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnCorrer;
                @Correr.canceled -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnCorrer;
                @Atacar.started -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnAtacar;
                @Atacar.performed -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnAtacar;
                @Atacar.canceled -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnAtacar;
                @Equiparespada.started -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnEquiparespada;
                @Equiparespada.performed -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnEquiparespada;
                @Equiparespada.canceled -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnEquiparespada;
                @Equiparbesta.started -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnEquiparbesta;
                @Equiparbesta.performed -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnEquiparbesta;
                @Equiparbesta.canceled -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnEquiparbesta;
                @Camera.started -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnCamera;
                @Interagir.started -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnInteragir;
                @Interagir.performed -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnInteragir;
                @Interagir.canceled -= m_Wrapper.m_PersonagemActionsCallbackInterface.OnInteragir;
            }
            m_Wrapper.m_PersonagemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mover.started += instance.OnMover;
                @Mover.performed += instance.OnMover;
                @Mover.canceled += instance.OnMover;
                @Correr.started += instance.OnCorrer;
                @Correr.performed += instance.OnCorrer;
                @Correr.canceled += instance.OnCorrer;
                @Atacar.started += instance.OnAtacar;
                @Atacar.performed += instance.OnAtacar;
                @Atacar.canceled += instance.OnAtacar;
                @Equiparespada.started += instance.OnEquiparespada;
                @Equiparespada.performed += instance.OnEquiparespada;
                @Equiparespada.canceled += instance.OnEquiparespada;
                @Equiparbesta.started += instance.OnEquiparbesta;
                @Equiparbesta.performed += instance.OnEquiparbesta;
                @Equiparbesta.canceled += instance.OnEquiparbesta;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Interagir.started += instance.OnInteragir;
                @Interagir.performed += instance.OnInteragir;
                @Interagir.canceled += instance.OnInteragir;
            }
        }
    }
    public PersonagemActions @Personagem => new PersonagemActions(this);
    public interface IPersonagemActions
    {
        void OnMover(InputAction.CallbackContext context);
        void OnCorrer(InputAction.CallbackContext context);
        void OnAtacar(InputAction.CallbackContext context);
        void OnEquiparespada(InputAction.CallbackContext context);
        void OnEquiparbesta(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnInteragir(InputAction.CallbackContext context);
    }
}
