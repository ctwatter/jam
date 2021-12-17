// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""afe8c594-1380-40a7-b268-823566f314b5"",
            ""actions"": [
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cd6710fa-4346-4d59-8025-5116a38b8267"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""f1605ff3-0031-4f0e-bf0c-ee08b67ef3db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e5aabfe5-abda-47d4-8084-70deb971d5cc"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a53cf9a-219c-45d1-bded-bd6e3ac9c14f"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_TouchPosition = m_Touch.FindAction("TouchPosition", throwIfNotFound: true);
        m_Touch_TouchPress = m_Touch.FindAction("TouchPress", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_TouchPosition;
    private readonly InputAction m_Touch_TouchPress;
    public struct TouchActions
    {
        private @TouchControls m_Wrapper;
        public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPosition => m_Wrapper.m_Touch_TouchPosition;
        public InputAction @TouchPress => m_Wrapper.m_Touch_TouchPress;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @TouchPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                @TouchPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
    }
}
