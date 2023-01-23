using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] bool _number1Triggered;
    [SerializeField] Vector2 _moveInput;
    [SerializeField] float _rotationInput;
    [SerializeField] Vector2 _lastMousePosition;
    [SerializeField] bool _zoomIn;
    [SerializeField] bool _zoomOut;
    [SerializeField] bool _dragPanMoveActive;
    [SerializeField] Vector2 _zoomInWheel;
    [SerializeField] bool _number1;
    [SerializeField] bool _leftClick;
    [SerializeField] bool _leftShift;
    [SerializeField] bool _rightClick;

    Inputs _inputs;
    Inputs Inputs => _inputs;
    
    public bool Number1Triggered => _number1Triggered;
    public bool Number1 => _number1;
    public Vector2 MoveInput => _moveInput;
    public float RotationInput => _rotationInput;
    public Vector2 LastMousePosition => _lastMousePosition;
    public bool ZoomIn => _zoomIn;
    public bool ZoomOut => _zoomOut;
    public Vector2 ZoomInWheel => _zoomInWheel;
    public bool DragPanMoveActive => _dragPanMoveActive;
    public bool LeftClick => _leftClick;

    public bool LeftShift => _leftShift;

    public bool RightClick => _rightClick;

    void Awake()
    {
        _inputs = new Inputs();
        
    }

    void Update()
    {
        _moveInput = _inputs.MapControls.Movement.ReadValue<Vector2>();
        _rotationInput = _inputs.MapControls.Rotation.ReadValue<float>();
        _zoomIn = _inputs.MapControls.ZoomIn.triggered;
        _zoomOut = _inputs.MapControls.ZoomOut.triggered;
        _zoomInWheel = _inputs.MapControls.ZoomInWheel.ReadValue<Vector2>();
        _number1Triggered = _inputs.MapControls.Number1.triggered;
        _leftClick = _inputs.MapControls.LeftClick.triggered || _inputs.ShapeBuilderControls.LeftClick.triggered;
        _rightClick = _inputs.MapControls.RightClick.triggered;


       //_leftClick = _inputs.ShapeBuilderControls.LeftClick.triggered;


    }

    public void SwapControlsToLines()
    {
        _inputs.MapControls.Disable();
        _inputs.ShapeBuilderControls.Enable();
    }

    public void SwapControlsToMap()
    {
        _inputs.ShapeBuilderControls.Enable();
        _inputs.MapControls.Enable();
    }



    void OnDragPanMoveStarted(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _dragPanMoveActive = true;
            _lastMousePosition = Mouse.current.position.ReadValue();
        }
    }

    void OnDragPanMoveCancelled(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _dragPanMoveActive = false;
        }
    }
    void OnLeftShiftStarted(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _leftShift = true;
        }
    }
    void OnLeftShiftCancelled(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _leftShift = false;
        }
    }

    void OnEnable()
    {
        SwapControlsToMap();
        _inputs.MapControls.DragPanMove.started += OnDragPanMoveStarted;
        _inputs.MapControls.DragPanMove.canceled += OnDragPanMoveCancelled;
        _inputs.MapControls.LeftShift.started += OnLeftShiftStarted;
        _inputs.MapControls.LeftShift.canceled += OnLeftShiftCancelled;

    }

    


    void OnDisable()
    {
        _inputs.MapControls.Disable();
        _inputs.MapControls.DragPanMove.started -= OnDragPanMoveStarted;
        _inputs.MapControls.DragPanMove.canceled -= OnDragPanMoveCancelled;
        _inputs.MapControls.LeftShift.started -= OnLeftShiftStarted;
        _inputs.MapControls.LeftShift.canceled -= OnLeftShiftCancelled;
    }
}