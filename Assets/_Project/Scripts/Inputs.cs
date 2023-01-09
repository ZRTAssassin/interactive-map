//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_Project/Input Action Asset.inputactions
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

public partial class @Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Action Asset"",
    ""maps"": [
        {
            ""name"": ""Map Controls"",
            ""id"": ""c48dd577-f4a5-4938-a1f7-e2bdb950d66d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""2ebddc68-7a19-4549-bd1e-f8ea411f5b08"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom In"",
                    ""type"": ""Button"",
                    ""id"": ""70c12f1b-dd63-40db-b6fa-22d5726687e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom Out"",
                    ""type"": ""Button"",
                    ""id"": ""eeb2e336-5aee-49f2-85a8-64c52adabfaa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ZoomInWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1555cb97-ea61-410f-b426-ff3d12e28608"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b61d5087-a4e0-480f-8fc0-0db7eda91e85"",
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
                    ""id"": ""c51bdba2-4a71-4aeb-9777-0e72f32548ea"",
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
                    ""id"": ""e6992d4f-6cdf-428e-975e-a23cc45dd444"",
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
                    ""id"": ""36803c74-05ea-4046-a347-8b52bb08c66f"",
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
                    ""id"": ""298f84bb-3c14-4aac-aa80-67062f710904"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dd41f242-5d14-419d-ba2d-8f81bdf6bd20"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom In"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c03b73a-ea3a-4f42-a76a-2ac161a55104"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom Out"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4941f76d-249e-4094-a7a9-530da7de4f1d"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""ZoomInWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Map Controls
        m_MapControls = asset.FindActionMap("Map Controls", throwIfNotFound: true);
        m_MapControls_Movement = m_MapControls.FindAction("Movement", throwIfNotFound: true);
        m_MapControls_ZoomIn = m_MapControls.FindAction("Zoom In", throwIfNotFound: true);
        m_MapControls_ZoomOut = m_MapControls.FindAction("Zoom Out", throwIfNotFound: true);
        m_MapControls_ZoomInWheel = m_MapControls.FindAction("ZoomInWheel", throwIfNotFound: true);
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

    // Map Controls
    private readonly InputActionMap m_MapControls;
    private IMapControlsActions m_MapControlsActionsCallbackInterface;
    private readonly InputAction m_MapControls_Movement;
    private readonly InputAction m_MapControls_ZoomIn;
    private readonly InputAction m_MapControls_ZoomOut;
    private readonly InputAction m_MapControls_ZoomInWheel;
    public struct MapControlsActions
    {
        private @Inputs m_Wrapper;
        public MapControlsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MapControls_Movement;
        public InputAction @ZoomIn => m_Wrapper.m_MapControls_ZoomIn;
        public InputAction @ZoomOut => m_Wrapper.m_MapControls_ZoomOut;
        public InputAction @ZoomInWheel => m_Wrapper.m_MapControls_ZoomInWheel;
        public InputActionMap Get() { return m_Wrapper.m_MapControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMapControlsActions instance)
        {
            if (m_Wrapper.m_MapControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnMovement;
                @ZoomIn.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomIn;
                @ZoomIn.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomIn;
                @ZoomIn.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomIn;
                @ZoomOut.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomOut;
                @ZoomOut.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomOut;
                @ZoomOut.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomOut;
                @ZoomInWheel.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomInWheel;
                @ZoomInWheel.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomInWheel;
                @ZoomInWheel.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomInWheel;
            }
            m_Wrapper.m_MapControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @ZoomIn.started += instance.OnZoomIn;
                @ZoomIn.performed += instance.OnZoomIn;
                @ZoomIn.canceled += instance.OnZoomIn;
                @ZoomOut.started += instance.OnZoomOut;
                @ZoomOut.performed += instance.OnZoomOut;
                @ZoomOut.canceled += instance.OnZoomOut;
                @ZoomInWheel.started += instance.OnZoomInWheel;
                @ZoomInWheel.performed += instance.OnZoomInWheel;
                @ZoomInWheel.canceled += instance.OnZoomInWheel;
            }
        }
    }
    public MapControlsActions @MapControls => new MapControlsActions(this);
    public interface IMapControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnZoomIn(InputAction.CallbackContext context);
        void OnZoomOut(InputAction.CallbackContext context);
        void OnZoomInWheel(InputAction.CallbackContext context);
    }
}