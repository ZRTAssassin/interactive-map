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
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""541d7a5c-4798-4944-abe2-468fef21d1c7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DragPanMove"",
                    ""type"": ""Button"",
                    ""id"": ""63411bcb-43b6-4fc1-936c-5a5e31837d7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Number1"",
                    ""type"": ""Button"",
                    ""id"": ""a07f3944-711a-4031-a9f7-0eb1799a8ef7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
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
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""73fad8f9-df4a-4578-a0da-c0cb2e7494ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftShift"",
                    ""type"": ""Button"",
                    ""id"": ""a4c56b51-cc01-4a7f-bb5f-0cc968c5504e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""3ca9c4c3-9492-447b-878b-153fd641ad87"",
                    ""expectedControlType"": ""Button"",
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
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomInWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee8bb86-6481-4789-b03d-af73df73537e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""404de2a6-133e-417a-8de2-6285f0b19794"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""374aaa11-ba42-4b11-9388-dc30d468f657"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""2fedca39-4fe4-440a-8486-c2ba474c25de"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9b44bfbb-a3bb-4826-b33a-7ed9eb6b1c4b"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DragPanMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""353c95d9-e064-4934-a549-a7f0ac288f7e"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3491b6ac-d22e-45e8-bfd0-008f6dcf4f53"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81d9008a-9614-4ecf-94bd-9a8b4dda8ca8"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftShift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shape Builder Controls"",
            ""id"": ""aabf667a-2263-464e-ada7-9255f80671f7"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""7abed3a3-8198-406c-86c4-e42a597ac161"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""450c2040-a302-4159-804a-736938c9760a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
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
        m_MapControls_Rotation = m_MapControls.FindAction("Rotation", throwIfNotFound: true);
        m_MapControls_DragPanMove = m_MapControls.FindAction("DragPanMove", throwIfNotFound: true);
        m_MapControls_Number1 = m_MapControls.FindAction("Number1", throwIfNotFound: true);
        m_MapControls_ZoomIn = m_MapControls.FindAction("Zoom In", throwIfNotFound: true);
        m_MapControls_ZoomOut = m_MapControls.FindAction("Zoom Out", throwIfNotFound: true);
        m_MapControls_ZoomInWheel = m_MapControls.FindAction("ZoomInWheel", throwIfNotFound: true);
        m_MapControls_LeftClick = m_MapControls.FindAction("LeftClick", throwIfNotFound: true);
        m_MapControls_LeftShift = m_MapControls.FindAction("LeftShift", throwIfNotFound: true);
        m_MapControls_RightClick = m_MapControls.FindAction("RightClick", throwIfNotFound: true);
        // Shape Builder Controls
        m_ShapeBuilderControls = asset.FindActionMap("Shape Builder Controls", throwIfNotFound: true);
        m_ShapeBuilderControls_LeftClick = m_ShapeBuilderControls.FindAction("LeftClick", throwIfNotFound: true);
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
    private readonly InputAction m_MapControls_Rotation;
    private readonly InputAction m_MapControls_DragPanMove;
    private readonly InputAction m_MapControls_Number1;
    private readonly InputAction m_MapControls_ZoomIn;
    private readonly InputAction m_MapControls_ZoomOut;
    private readonly InputAction m_MapControls_ZoomInWheel;
    private readonly InputAction m_MapControls_LeftClick;
    private readonly InputAction m_MapControls_LeftShift;
    private readonly InputAction m_MapControls_RightClick;
    public struct MapControlsActions
    {
        private @Inputs m_Wrapper;
        public MapControlsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MapControls_Movement;
        public InputAction @Rotation => m_Wrapper.m_MapControls_Rotation;
        public InputAction @DragPanMove => m_Wrapper.m_MapControls_DragPanMove;
        public InputAction @Number1 => m_Wrapper.m_MapControls_Number1;
        public InputAction @ZoomIn => m_Wrapper.m_MapControls_ZoomIn;
        public InputAction @ZoomOut => m_Wrapper.m_MapControls_ZoomOut;
        public InputAction @ZoomInWheel => m_Wrapper.m_MapControls_ZoomInWheel;
        public InputAction @LeftClick => m_Wrapper.m_MapControls_LeftClick;
        public InputAction @LeftShift => m_Wrapper.m_MapControls_LeftShift;
        public InputAction @RightClick => m_Wrapper.m_MapControls_RightClick;
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
                @Rotation.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnRotation;
                @DragPanMove.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnDragPanMove;
                @DragPanMove.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnDragPanMove;
                @DragPanMove.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnDragPanMove;
                @Number1.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnNumber1;
                @Number1.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnNumber1;
                @Number1.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnNumber1;
                @ZoomIn.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomIn;
                @ZoomIn.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomIn;
                @ZoomIn.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomIn;
                @ZoomOut.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomOut;
                @ZoomOut.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomOut;
                @ZoomOut.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomOut;
                @ZoomInWheel.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomInWheel;
                @ZoomInWheel.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomInWheel;
                @ZoomInWheel.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnZoomInWheel;
                @LeftClick.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnLeftClick;
                @LeftShift.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnLeftShift;
                @LeftShift.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnLeftShift;
                @LeftShift.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnLeftShift;
                @RightClick.started -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_MapControlsActionsCallbackInterface.OnRightClick;
            }
            m_Wrapper.m_MapControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @DragPanMove.started += instance.OnDragPanMove;
                @DragPanMove.performed += instance.OnDragPanMove;
                @DragPanMove.canceled += instance.OnDragPanMove;
                @Number1.started += instance.OnNumber1;
                @Number1.performed += instance.OnNumber1;
                @Number1.canceled += instance.OnNumber1;
                @ZoomIn.started += instance.OnZoomIn;
                @ZoomIn.performed += instance.OnZoomIn;
                @ZoomIn.canceled += instance.OnZoomIn;
                @ZoomOut.started += instance.OnZoomOut;
                @ZoomOut.performed += instance.OnZoomOut;
                @ZoomOut.canceled += instance.OnZoomOut;
                @ZoomInWheel.started += instance.OnZoomInWheel;
                @ZoomInWheel.performed += instance.OnZoomInWheel;
                @ZoomInWheel.canceled += instance.OnZoomInWheel;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @LeftShift.started += instance.OnLeftShift;
                @LeftShift.performed += instance.OnLeftShift;
                @LeftShift.canceled += instance.OnLeftShift;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
            }
        }
    }
    public MapControlsActions @MapControls => new MapControlsActions(this);

    // Shape Builder Controls
    private readonly InputActionMap m_ShapeBuilderControls;
    private IShapeBuilderControlsActions m_ShapeBuilderControlsActionsCallbackInterface;
    private readonly InputAction m_ShapeBuilderControls_LeftClick;
    public struct ShapeBuilderControlsActions
    {
        private @Inputs m_Wrapper;
        public ShapeBuilderControlsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_ShapeBuilderControls_LeftClick;
        public InputActionMap Get() { return m_Wrapper.m_ShapeBuilderControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShapeBuilderControlsActions set) { return set.Get(); }
        public void SetCallbacks(IShapeBuilderControlsActions instance)
        {
            if (m_Wrapper.m_ShapeBuilderControlsActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_ShapeBuilderControlsActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_ShapeBuilderControlsActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_ShapeBuilderControlsActionsCallbackInterface.OnLeftClick;
            }
            m_Wrapper.m_ShapeBuilderControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
            }
        }
    }
    public ShapeBuilderControlsActions @ShapeBuilderControls => new ShapeBuilderControlsActions(this);
    public interface IMapControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnDragPanMove(InputAction.CallbackContext context);
        void OnNumber1(InputAction.CallbackContext context);
        void OnZoomIn(InputAction.CallbackContext context);
        void OnZoomOut(InputAction.CallbackContext context);
        void OnZoomInWheel(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnLeftShift(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
    }
    public interface IShapeBuilderControlsActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
    }
}
