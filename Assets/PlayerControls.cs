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
            ""name"": ""DefaultInput"",
            ""id"": ""10d33d38-8e6d-438f-8308-31bc94c3a119"",
            ""actions"": [
                {
                    ""name"": ""onPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c0a30c6e-2012-4de2-b020-7807824428e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ff823971-15c4-47b7-8974-7d67be9b46ea"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""onPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DefaultInput
        m_DefaultInput = asset.FindActionMap("DefaultInput", throwIfNotFound: true);
        m_DefaultInput_onPress = m_DefaultInput.FindAction("onPress", throwIfNotFound: true);
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

    // DefaultInput
    private readonly InputActionMap m_DefaultInput;
    private IDefaultInputActions m_DefaultInputActionsCallbackInterface;
    private readonly InputAction m_DefaultInput_onPress;
    public struct DefaultInputActions
    {
        private @PlayerControls m_Wrapper;
        public DefaultInputActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @onPress => m_Wrapper.m_DefaultInput_onPress;
        public InputActionMap Get() { return m_Wrapper.m_DefaultInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultInputActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultInputActions instance)
        {
            if (m_Wrapper.m_DefaultInputActionsCallbackInterface != null)
            {
                @onPress.started -= m_Wrapper.m_DefaultInputActionsCallbackInterface.OnOnPress;
                @onPress.performed -= m_Wrapper.m_DefaultInputActionsCallbackInterface.OnOnPress;
                @onPress.canceled -= m_Wrapper.m_DefaultInputActionsCallbackInterface.OnOnPress;
            }
            m_Wrapper.m_DefaultInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @onPress.started += instance.OnOnPress;
                @onPress.performed += instance.OnOnPress;
                @onPress.canceled += instance.OnOnPress;
            }
        }
    }
    public DefaultInputActions @DefaultInput => new DefaultInputActions(this);
    public interface IDefaultInputActions
    {
        void OnOnPress(InputAction.CallbackContext context);
    }
}
