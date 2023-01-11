using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTargetMovement : MonoBehaviour
{
    [Space(10f)] [Header("Debug")] [SerializeField]
    bool _enableLogging;

    [Header("Feature Toggle")] [Space(5f)] [SerializeField]
    bool _useDragPan = false;

    [SerializeField] bool _useRotation = false;

    [Space(10f), Header("Camera Setup")] [SerializeField]
    CinemachineVirtualCamera _camera;

    [SerializeField] Vector2 _minVector;
    [SerializeField] Vector2 _maxVector;
    [Space(10f)] [SerializeField] float _moveSpeed;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _dragPanSpeed = 1.5f;
    [SerializeField] float _targetLensSize;
    [Space(10f)] [SerializeField] float _zoomInMax = 1;
    [SerializeField] float _zoomOutMax = 25;

    Inputs _inputs;
    Vector2 _moveInput;
    Vector2 _lastMousePosition;
    bool _zoomIn;
    bool _zoomOut;
    bool _dragPanMoveActive;
    Vector2 _zoomInWheel;
    float _rotationInput;

    public Inputs Inputs => _inputs;


    // adapt for zoom https://www.youtube.com/watch?v=5Ue0waWtkY4
    // https://www.youtube.com/watch?v=Qd3hkKM-UTI
    // code monkey: https://www.youtube.com/watch?v=pJQndtJ2rk0

    void Awake()
    {
        _inputs = new Inputs();
    }

    void Start()
    {
        _camera.m_Lens.OrthographicSize = 1;
    }

    void Update()
    {
        GetInput();
        HandleMovement();
        if (_useDragPan)
            HandleMovementDragPan();
        if (_useRotation)
            HandleRotation();
        HandleCameraZoom();
    }

    void HandleMovement()
    {
        var inputDir = new Vector2(_moveInput.x, _moveInput.y);
        var moveDir = transform.up * inputDir.y + transform.right * inputDir.x;
        transform.position += moveDir * (_moveSpeed * Time.deltaTime);
        ConfineCamera();
    }

    void HandleMovementDragPan()
    {
        var inputDir = new Vector2(_moveInput.x, _moveInput.y);
        if (_dragPanMoveActive)
        {
            Vector2 mouseMovementDelta = Mouse.current.position.ReadValue() - _lastMousePosition;
            mouseMovementDelta.Normalize();

            inputDir.x = mouseMovementDelta.x * _dragPanSpeed * -1;
            inputDir.y = mouseMovementDelta.y * _dragPanSpeed * -1;
        }

        var moveDir = transform.up * inputDir.y + transform.right * inputDir.x;

        transform.position += moveDir * (_moveSpeed * Time.deltaTime);
    }

    void HandleRotation()
    {
        float rotateDir = _rotationInput;
        transform.eulerAngles += new Vector3(0, 0, rotateDir * _rotationSpeed * Time.deltaTime);
    }

    void GetInput()
    {
        _moveInput = _inputs.MapControls.Movement.ReadValue<Vector2>();
        _rotationInput = _inputs.MapControls.Rotation.ReadValue<float>();
        _zoomIn = _inputs.MapControls.ZoomIn.triggered;
        _zoomOut = _inputs.MapControls.ZoomOut.triggered;
        _zoomInWheel = _inputs.MapControls.ZoomInWheel.ReadValue<Vector2>();
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

    void HandleCameraZoom()
    {
        // Log($"{_zoomInWheel}");
        if (_zoomInWheel.y > 0)
            _targetLensSize -= 1;
        if (_zoomInWheel.y < 0)
            _targetLensSize += 1;
        if (_zoomIn)
            _targetLensSize -= 1;
        if (_zoomOut)
            _targetLensSize += 1;

        _targetLensSize = Mathf.Clamp(_targetLensSize, _zoomInMax, _zoomOutMax);

        _camera.m_Lens.OrthographicSize = Mathf.Lerp(_camera.m_Lens.OrthographicSize, _targetLensSize, 0.2f);
    }

    void ConfineCamera()
    {
        if (transform.position.x > _maxVector.x)
        {
            transform.position = new Vector2(_maxVector.x, transform.position.y);
        }
        else if (transform.position.x < _minVector.x)
        {
            transform.position = new Vector2(_minVector.x, transform.position.y);
        }

        if (transform.position.y > _maxVector.y)
        {
            transform.position = new Vector2(transform.position.x, _maxVector.y);
        }
        else if (transform.position.y < _minVector.y)
        {
            transform.position = new Vector2(transform.position.x, _minVector.y);
        }
    }

    [ContextMenu("Toggle Drag Pan")]
    public void ToggleDragPan()
    {
        _useDragPan = !_useDragPan;
    }


    void Log(string message)
    {
        if (_enableLogging)
        {
            Debug.Log(message);
        }
    }

    void OnEnable()
    {
        _inputs.MapControls.Enable();
        _inputs.MapControls.DragPanMove.started += OnDragPanMoveStarted;
        _inputs.MapControls.DragPanMove.canceled += OnDragPanMoveCancelled;
    }

    void OnDisable()
    {
        _inputs.MapControls.Disable();
        _inputs.MapControls.DragPanMove.started -= OnDragPanMoveStarted;
        _inputs.MapControls.DragPanMove.canceled -= OnDragPanMoveCancelled;
    }
}