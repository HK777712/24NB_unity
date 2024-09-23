//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/GameInputs.inputactions
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

public partial class @GameInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d785623b-390d-42a0-adbb-c5af2df05aee"",
            ""actions"": [
                {
                    ""name"": ""Maru"",
                    ""type"": ""Button"",
                    ""id"": ""7ed971df-b1ce-495d-b869-7da4cef2d9e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Batu"",
                    ""type"": ""Button"",
                    ""id"": ""bf60c9a8-f3a5-4760-8c44-f5ad6e2f2988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sikaku"",
                    ""type"": ""Button"",
                    ""id"": ""3cfff595-a4e9-4b38-9587-56b6fa9c0ea1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sankaku"",
                    ""type"": ""Button"",
                    ""id"": ""490f55f4-6900-428e-8963-a9d45bef80fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""ce1c4e5a-fb5c-4faa-bb80-6557d63d7605"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""34d261a7-7900-428c-b225-de98f85af6e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""3af12b69-16f1-4085-ba23-934bea7bfbb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""ef818060-b153-49eb-a4a2-4a72cabef598"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""L1"",
                    ""type"": ""Button"",
                    ""id"": ""8990dfc6-98fa-4e1b-ba5b-7cbdf5ea440f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""L2"",
                    ""type"": ""Button"",
                    ""id"": ""990a8ffe-3197-44c8-ba6d-508ee0c99e30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""R1"",
                    ""type"": ""Button"",
                    ""id"": ""4cf968c2-2934-4e65-a326-8afa5472492a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""R2"",
                    ""type"": ""Button"",
                    ""id"": ""615a13ea-aa7d-43c1-9cc0-d394981c909c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e9ca5c4c-635c-40c3-a524-13de571cc7d5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dir"",
                    ""type"": ""Value"",
                    ""id"": ""3a3cd9f8-e08b-460e-94f5-9f7bfecfd3dc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d249447c-0955-4685-a9d5-6c29dcc8eb9f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Maru"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1530ded5-f642-4cb4-b09f-5f6898a1c41a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5495002b-d241-4991-aaaa-a6a8f2b8c2ee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2881557c-ca96-4c3d-babf-6f8dd94b89eb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7b40bcb5-03b4-488d-9813-9eb8007b6aec"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""077081b1-ae47-458a-8b60-23de29450577"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""946eaa89-95ac-4ea9-ae2a-cc4315638262"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9a03e539-6af6-46c1-82eb-fc447f73710f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dfd3ec17-63a9-4e35-9902-a80e3de710bd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dir"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ee510381-1dc5-4aac-b4f8-95954a590660"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""80999999-edce-4776-9c00-9619d39d1fbd"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e5f52499-6adb-4f26-8ba6-c8edf52102ca"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Batu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c984dc01-0110-4154-bd78-b0b86e49eea5"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sikaku"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4649a5b5-a94b-491b-9314-6639d1001e21"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sankaku"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d20b688-44ff-4e97-8e68-abf2f15aecb9"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cfb16ba-8375-4b4d-958c-e06a3246e3b7"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d4e5f45-641d-4338-adcd-735be2389a34"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7770dd79-781f-45ca-99e2-9a8a29020c4f"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea318f1c-cb72-47b3-a451-7bc5a7dd182f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92da74b3-5003-4e23-9364-0c1ec662de8c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65bab422-13bb-4ef6-8036-484903bc7e7b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33069a51-ecfd-4373-949a-2d27b3231aa7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Maru = m_Player.FindAction("Maru", throwIfNotFound: true);
        m_Player_Batu = m_Player.FindAction("Batu", throwIfNotFound: true);
        m_Player_Sikaku = m_Player.FindAction("Sikaku", throwIfNotFound: true);
        m_Player_Sankaku = m_Player.FindAction("Sankaku", throwIfNotFound: true);
        m_Player_Up = m_Player.FindAction("Up", throwIfNotFound: true);
        m_Player_Down = m_Player.FindAction("Down", throwIfNotFound: true);
        m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
        m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
        m_Player_L1 = m_Player.FindAction("L1", throwIfNotFound: true);
        m_Player_L2 = m_Player.FindAction("L2", throwIfNotFound: true);
        m_Player_R1 = m_Player.FindAction("R1", throwIfNotFound: true);
        m_Player_R2 = m_Player.FindAction("R2", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Dir = m_Player.FindAction("Dir", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Maru;
    private readonly InputAction m_Player_Batu;
    private readonly InputAction m_Player_Sikaku;
    private readonly InputAction m_Player_Sankaku;
    private readonly InputAction m_Player_Up;
    private readonly InputAction m_Player_Down;
    private readonly InputAction m_Player_Left;
    private readonly InputAction m_Player_Right;
    private readonly InputAction m_Player_L1;
    private readonly InputAction m_Player_L2;
    private readonly InputAction m_Player_R1;
    private readonly InputAction m_Player_R2;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Dir;
    public struct PlayerActions
    {
        private @GameInputs m_Wrapper;
        public PlayerActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Maru => m_Wrapper.m_Player_Maru;
        public InputAction @Batu => m_Wrapper.m_Player_Batu;
        public InputAction @Sikaku => m_Wrapper.m_Player_Sikaku;
        public InputAction @Sankaku => m_Wrapper.m_Player_Sankaku;
        public InputAction @Up => m_Wrapper.m_Player_Up;
        public InputAction @Down => m_Wrapper.m_Player_Down;
        public InputAction @Left => m_Wrapper.m_Player_Left;
        public InputAction @Right => m_Wrapper.m_Player_Right;
        public InputAction @L1 => m_Wrapper.m_Player_L1;
        public InputAction @L2 => m_Wrapper.m_Player_L2;
        public InputAction @R1 => m_Wrapper.m_Player_R1;
        public InputAction @R2 => m_Wrapper.m_Player_R2;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Dir => m_Wrapper.m_Player_Dir;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Maru.started += instance.OnMaru;
            @Maru.performed += instance.OnMaru;
            @Maru.canceled += instance.OnMaru;
            @Batu.started += instance.OnBatu;
            @Batu.performed += instance.OnBatu;
            @Batu.canceled += instance.OnBatu;
            @Sikaku.started += instance.OnSikaku;
            @Sikaku.performed += instance.OnSikaku;
            @Sikaku.canceled += instance.OnSikaku;
            @Sankaku.started += instance.OnSankaku;
            @Sankaku.performed += instance.OnSankaku;
            @Sankaku.canceled += instance.OnSankaku;
            @Up.started += instance.OnUp;
            @Up.performed += instance.OnUp;
            @Up.canceled += instance.OnUp;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
            @Left.started += instance.OnLeft;
            @Left.performed += instance.OnLeft;
            @Left.canceled += instance.OnLeft;
            @Right.started += instance.OnRight;
            @Right.performed += instance.OnRight;
            @Right.canceled += instance.OnRight;
            @L1.started += instance.OnL1;
            @L1.performed += instance.OnL1;
            @L1.canceled += instance.OnL1;
            @L2.started += instance.OnL2;
            @L2.performed += instance.OnL2;
            @L2.canceled += instance.OnL2;
            @R1.started += instance.OnR1;
            @R1.performed += instance.OnR1;
            @R1.canceled += instance.OnR1;
            @R2.started += instance.OnR2;
            @R2.performed += instance.OnR2;
            @R2.canceled += instance.OnR2;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Dir.started += instance.OnDir;
            @Dir.performed += instance.OnDir;
            @Dir.canceled += instance.OnDir;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Maru.started -= instance.OnMaru;
            @Maru.performed -= instance.OnMaru;
            @Maru.canceled -= instance.OnMaru;
            @Batu.started -= instance.OnBatu;
            @Batu.performed -= instance.OnBatu;
            @Batu.canceled -= instance.OnBatu;
            @Sikaku.started -= instance.OnSikaku;
            @Sikaku.performed -= instance.OnSikaku;
            @Sikaku.canceled -= instance.OnSikaku;
            @Sankaku.started -= instance.OnSankaku;
            @Sankaku.performed -= instance.OnSankaku;
            @Sankaku.canceled -= instance.OnSankaku;
            @Up.started -= instance.OnUp;
            @Up.performed -= instance.OnUp;
            @Up.canceled -= instance.OnUp;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
            @Left.started -= instance.OnLeft;
            @Left.performed -= instance.OnLeft;
            @Left.canceled -= instance.OnLeft;
            @Right.started -= instance.OnRight;
            @Right.performed -= instance.OnRight;
            @Right.canceled -= instance.OnRight;
            @L1.started -= instance.OnL1;
            @L1.performed -= instance.OnL1;
            @L1.canceled -= instance.OnL1;
            @L2.started -= instance.OnL2;
            @L2.performed -= instance.OnL2;
            @L2.canceled -= instance.OnL2;
            @R1.started -= instance.OnR1;
            @R1.performed -= instance.OnR1;
            @R1.canceled -= instance.OnR1;
            @R2.started -= instance.OnR2;
            @R2.performed -= instance.OnR2;
            @R2.canceled -= instance.OnR2;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Dir.started -= instance.OnDir;
            @Dir.performed -= instance.OnDir;
            @Dir.canceled -= instance.OnDir;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMaru(InputAction.CallbackContext context);
        void OnBatu(InputAction.CallbackContext context);
        void OnSikaku(InputAction.CallbackContext context);
        void OnSankaku(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnL1(InputAction.CallbackContext context);
        void OnL2(InputAction.CallbackContext context);
        void OnR1(InputAction.CallbackContext context);
        void OnR2(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnDir(InputAction.CallbackContext context);
    }
}
