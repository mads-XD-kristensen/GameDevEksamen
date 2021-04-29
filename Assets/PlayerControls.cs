// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""0ba95e07-177d-4fc2-b489-1899145ac2c5"",
            ""actions"": [
                {
                    ""name"": ""RunRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3920fa6f-c978-4bc8-a340-be80c5605d96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RunLeft"",
                    ""type"": ""PassThrough"",
                    ""id"": ""68ccf705-8e33-4c28-9e12-c830ffd2942d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9f390c55-b2c1-46cc-913f-e9ff836b1617"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9bad2fa6-8792-4a64-afb9-cb48cbaa2dfe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""990a2276-8ffb-44ea-92c1-742bd5a408c4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07ee4b17-093c-465e-8f2a-d7dee626bfec"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_RunRight = m_Controls.FindAction("RunRight", throwIfNotFound: true);
        m_Controls_RunLeft = m_Controls.FindAction("RunLeft", throwIfNotFound: true);
        m_Controls_Jump = m_Controls.FindAction("Jump", throwIfNotFound: true);
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

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_RunRight;
    private readonly InputAction m_Controls_RunLeft;
    private readonly InputAction m_Controls_Jump;
    public struct ControlsActions
    {
        private @PlayerControls m_Wrapper;
        public ControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RunRight => m_Wrapper.m_Controls_RunRight;
        public InputAction @RunLeft => m_Wrapper.m_Controls_RunLeft;
        public InputAction @Jump => m_Wrapper.m_Controls_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @RunRight.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRunRight;
                @RunRight.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRunRight;
                @RunRight.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRunRight;
                @RunLeft.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRunLeft;
                @RunLeft.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRunLeft;
                @RunLeft.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnRunLeft;
                @Jump.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RunRight.started += instance.OnRunRight;
                @RunRight.performed += instance.OnRunRight;
                @RunRight.canceled += instance.OnRunRight;
                @RunLeft.started += instance.OnRunLeft;
                @RunLeft.performed += instance.OnRunLeft;
                @RunLeft.canceled += instance.OnRunLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnRunRight(InputAction.CallbackContext context);
        void OnRunLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
