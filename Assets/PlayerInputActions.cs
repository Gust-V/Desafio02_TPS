//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerController"",
            ""id"": ""d7e16c76-312c-4fb2-a865-96784211e042"",
            ""actions"": [
                {
                    ""name"": ""JUMP"",
                    ""type"": ""Button"",
                    ""id"": ""4789b4f6-18d4-4640-a8de-03c649eea53d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RUN"",
                    ""type"": ""Button"",
                    ""id"": ""8e038277-6a5b-4481-ab18-a736853e6c80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1d23b844-15d5-4b30-887e-1b511b5ce62e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JUMP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""084f0d58-0aa8-464f-8700-3963c34d8634"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JUMP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce8be873-ff5f-4137-a8c1-e21909c6e0a9"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RUN"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player1"",
            ""id"": ""dda86165-9083-4e4d-8472-398f0468bac6"",
            ""actions"": [
                {
                    ""name"": ""MOVE"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f204a66b-35d4-44a6-a3f9-d1582f1f5ec0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LOOK"",
                    ""type"": ""Value"",
                    ""id"": ""9014053a-ea4a-414f-96e8-2e477659de9b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""JUMP"",
                    ""type"": ""Button"",
                    ""id"": ""10f0092b-903f-4390-b17e-125303712e36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AIM"",
                    ""type"": ""Button"",
                    ""id"": ""d05450e6-5b6c-4b4d-8377-b2cf8299232b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SHOOT"",
                    ""type"": ""Button"",
                    ""id"": ""4c9b5610-ddef-4a31-b1ec-bc59a95f131a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""38d8e9a9-a46a-44fb-8caf-7eab64647085"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e9d0015-a984-4822-8e1a-7a1ba468ff3d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""65771123-fa73-4fec-b53f-fe082241bb90"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f5929d9e-3ed5-407c-a1b3-eed656cebfec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b5db01a2-cac8-40fd-a1ba-dc6cdee6a9a3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""L_STICK"",
                    ""id"": ""567c8596-28fd-434c-aa4d-a9b67c4a1e5c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1a4c04a4-4f77-4da9-9737-a30ad7791f00"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""493ea872-2fd9-4928-9bdb-6024f7e9f423"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""373e0367-d641-4caf-aa3e-7246e01b8e92"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7c403118-e8ea-499a-9e23-78d4a0ffea4b"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MOVE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""505800e9-39cc-4110-91ca-3af485bbb33b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LOOK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6af9ce71-ea32-4aca-9d64-d1b509e641d4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JUMP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f29dda9f-c54a-496c-829d-b6d4394fd02c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AIM"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e38d370-6603-4c86-b282-51237050690b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SHOOT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerController
        m_PlayerController = asset.FindActionMap("PlayerController", throwIfNotFound: true);
        m_PlayerController_JUMP = m_PlayerController.FindAction("JUMP", throwIfNotFound: true);
        m_PlayerController_RUN = m_PlayerController.FindAction("RUN", throwIfNotFound: true);
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_MOVE = m_Player1.FindAction("MOVE", throwIfNotFound: true);
        m_Player1_LOOK = m_Player1.FindAction("LOOK", throwIfNotFound: true);
        m_Player1_JUMP = m_Player1.FindAction("JUMP", throwIfNotFound: true);
        m_Player1_AIM = m_Player1.FindAction("AIM", throwIfNotFound: true);
        m_Player1_SHOOT = m_Player1.FindAction("SHOOT", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerController
    private readonly InputActionMap m_PlayerController;
    private IPlayerControllerActions m_PlayerControllerActionsCallbackInterface;
    private readonly InputAction m_PlayerController_JUMP;
    private readonly InputAction m_PlayerController_RUN;
    public struct PlayerControllerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControllerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @JUMP => m_Wrapper.m_PlayerController_JUMP;
        public InputAction @RUN => m_Wrapper.m_PlayerController_RUN;
        public InputActionMap Get() { return m_Wrapper.m_PlayerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControllerActions instance)
        {
            if (m_Wrapper.m_PlayerControllerActionsCallbackInterface != null)
            {
                @JUMP.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJUMP;
                @JUMP.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJUMP;
                @JUMP.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJUMP;
                @RUN.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnRUN;
                @RUN.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnRUN;
                @RUN.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnRUN;
            }
            m_Wrapper.m_PlayerControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JUMP.started += instance.OnJUMP;
                @JUMP.performed += instance.OnJUMP;
                @JUMP.canceled += instance.OnJUMP;
                @RUN.started += instance.OnRUN;
                @RUN.performed += instance.OnRUN;
                @RUN.canceled += instance.OnRUN;
            }
        }
    }
    public PlayerControllerActions @PlayerController => new PlayerControllerActions(this);

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_MOVE;
    private readonly InputAction m_Player1_LOOK;
    private readonly InputAction m_Player1_JUMP;
    private readonly InputAction m_Player1_AIM;
    private readonly InputAction m_Player1_SHOOT;
    public struct Player1Actions
    {
        private @PlayerInputActions m_Wrapper;
        public Player1Actions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MOVE => m_Wrapper.m_Player1_MOVE;
        public InputAction @LOOK => m_Wrapper.m_Player1_LOOK;
        public InputAction @JUMP => m_Wrapper.m_Player1_JUMP;
        public InputAction @AIM => m_Wrapper.m_Player1_AIM;
        public InputAction @SHOOT => m_Wrapper.m_Player1_SHOOT;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @MOVE.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMOVE;
                @MOVE.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMOVE;
                @MOVE.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMOVE;
                @LOOK.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLOOK;
                @LOOK.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLOOK;
                @LOOK.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLOOK;
                @JUMP.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJUMP;
                @JUMP.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJUMP;
                @JUMP.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJUMP;
                @AIM.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAIM;
                @AIM.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAIM;
                @AIM.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAIM;
                @SHOOT.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSHOOT;
                @SHOOT.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSHOOT;
                @SHOOT.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSHOOT;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MOVE.started += instance.OnMOVE;
                @MOVE.performed += instance.OnMOVE;
                @MOVE.canceled += instance.OnMOVE;
                @LOOK.started += instance.OnLOOK;
                @LOOK.performed += instance.OnLOOK;
                @LOOK.canceled += instance.OnLOOK;
                @JUMP.started += instance.OnJUMP;
                @JUMP.performed += instance.OnJUMP;
                @JUMP.canceled += instance.OnJUMP;
                @AIM.started += instance.OnAIM;
                @AIM.performed += instance.OnAIM;
                @AIM.canceled += instance.OnAIM;
                @SHOOT.started += instance.OnSHOOT;
                @SHOOT.performed += instance.OnSHOOT;
                @SHOOT.canceled += instance.OnSHOOT;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    public interface IPlayerControllerActions
    {
        void OnJUMP(InputAction.CallbackContext context);
        void OnRUN(InputAction.CallbackContext context);
    }
    public interface IPlayer1Actions
    {
        void OnMOVE(InputAction.CallbackContext context);
        void OnLOOK(InputAction.CallbackContext context);
        void OnJUMP(InputAction.CallbackContext context);
        void OnAIM(InputAction.CallbackContext context);
        void OnSHOOT(InputAction.CallbackContext context);
    }
}