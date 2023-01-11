using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    Inputs _cameraActions;
    InputAction _movement;
    Transform _cameraTransform;

    [BoxGroup("Horizontal Translation")] [SerializeField]
    float _maxSpeed = 5f;

    float _speed;

    [BoxGroup("Horizontal Translation")] [SerializeField]
    float _acceleration = 10f;

    [BoxGroup("Horizontal Translation")] [SerializeField]
    float _damping = 15f;

    [BoxGroup("Vertical Translation")] [SerializeField]
    float _stepSize = 2f;

    [BoxGroup("Vertical Translation")] [SerializeField]
    float _zoomDampening = 7.5f;

    [BoxGroup("Vertical Translation")] [SerializeField]
    float _minHeight = 5f;

    [BoxGroup("Vertical Translation")] [SerializeField]
    float _maxHeight = 50f;

    [BoxGroup("Vertical Translation")] [SerializeField]
    float _zoomSpeed = 2f;

    [BoxGroup("Rotation")] [SerializeField]
    float _maxRotationSpeed = 1f;

    [BoxGroup("Edge Movement")] [SerializeField] [Range(0f, 0.1f)]
    float _edgeTolerance = 0.05f;

    //value set in various functions 
    //used to update the position of the camera base object.
    Vector3 _targetPosition;

    float _zoomHeight;

    //used to track and maintain velocity w/o a rigidbody
    Vector3 _horizontalVelocity;
    Vector3 _lastPosition;

    //tracks where the dragging action started
    Vector3 _startDrag;

    void Awake()
    {
        _cameraActions = new Inputs();
        _cameraTransform = this.GetComponentInChildren<Camera>().transform;
    }

    void OnEnable()
    {
        _zoomHeight = _cameraTransform.localPosition.y;
        _cameraTransform.LookAt(this.transform);

        _lastPosition = this.transform.position;

        _movement = _cameraActions.CameraOneWheel.Movement;
        _cameraActions.CameraOneWheel.RotateCamera.performed += RotateCamera;
        _cameraActions.CameraOneWheel.ZoomCamera.performed += ZoomCamera;
        _cameraActions.CameraOneWheel.Enable();
    }

    void OnDisable()
    {
        _cameraActions.CameraOneWheel.RotateCamera.performed -= RotateCamera;
        _cameraActions.CameraOneWheel.ZoomCamera.performed -= ZoomCamera;
        _cameraActions.CameraOneWheel.Disable();
    }

    void Update()
    {
        //inputs
        GetKeyboardMovement();
        CheckMouseAtScreenEdge();
        DragCamera();

        //move base and camera objects
        UpdateVelocity();
        UpdateBasePosition();
        UpdateCameraPosition();
    }

    void UpdateVelocity()
    {
        _horizontalVelocity = (this.transform.position - _lastPosition) / Time.deltaTime;
        _horizontalVelocity.y = 0f;
        _lastPosition = this.transform.position;
    }

    void GetKeyboardMovement()
    {
        Vector3 inputValue = _movement.ReadValue<Vector2>().x * GetCameraRight()
                             + _movement.ReadValue<Vector2>().y * GetCameraForward();

        inputValue = inputValue.normalized;

        if (inputValue.sqrMagnitude > 0.1f)
            _targetPosition += inputValue;
    }

    void DragCamera()
    {
        if (!Mouse.current.rightButton.isPressed)
            return;

        //create plane to raycast to
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (plane.Raycast(ray, out float distance))
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
                _startDrag = ray.GetPoint(distance);
            else
                _targetPosition += _startDrag - ray.GetPoint(distance);
        }
    }

    void CheckMouseAtScreenEdge()
    {
        //mouse position is in pixels
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 moveDirection = Vector3.zero;

        //horizontal scrolling
        if (mousePosition.x < _edgeTolerance * Screen.width)
            moveDirection += -GetCameraRight();
        else if (mousePosition.x > (1f - _edgeTolerance) * Screen.width)
            moveDirection += GetCameraRight();

        //vertical scrolling
        if (mousePosition.y < _edgeTolerance * Screen.height)
            moveDirection += -GetCameraForward();
        else if (mousePosition.y > (1f - _edgeTolerance) * Screen.height)
            moveDirection += GetCameraForward();

        _targetPosition += moveDirection;
    }

    void UpdateBasePosition()
    {
        if (_targetPosition.sqrMagnitude > 0.1f)
        {
            //create a ramp up or acceleration
            _speed = Mathf.Lerp(_speed, _maxSpeed, Time.deltaTime * _acceleration);
            transform.position += _targetPosition * _speed * Time.deltaTime;
        }
        else
        {
            //create smooth slow down
            _horizontalVelocity = Vector3.Lerp(_horizontalVelocity, Vector3.zero, Time.deltaTime * _damping);
            transform.position += _horizontalVelocity * Time.deltaTime;
        }

        //reset for next frame
        _targetPosition = Vector3.zero;
    }

    void ZoomCamera(InputAction.CallbackContext obj)
    {
        float inputValue = -obj.ReadValue<Vector2>().y / 100f;

        if (Mathf.Abs(inputValue) > 0.1f)
        {
            _zoomHeight = _cameraTransform.localPosition.y + inputValue * _stepSize;

            if (_zoomHeight < _minHeight)
                _zoomHeight = _minHeight;
            else if (_zoomHeight > _maxHeight)
                _zoomHeight = _maxHeight;
        }
    }

    void UpdateCameraPosition()
    {
        //set zoom target
        Vector3 zoomTarget =
            new Vector3(_cameraTransform.localPosition.x, _zoomHeight, _cameraTransform.localPosition.z);
        //add vector for forward/backward zoom
        zoomTarget -= _zoomSpeed * (_zoomHeight - _cameraTransform.localPosition.y) * Vector3.forward;

        _cameraTransform.localPosition =
            Vector3.Lerp(_cameraTransform.localPosition, zoomTarget, Time.deltaTime * _zoomDampening);
        _cameraTransform.LookAt(this.transform);
    }

    void RotateCamera(InputAction.CallbackContext obj)
    {
        if (!Mouse.current.middleButton.isPressed)
            return;

        float inputValue = obj.ReadValue<Vector2>().x;
        transform.rotation =
            Quaternion.Euler(0f, inputValue * _maxRotationSpeed + transform.rotation.eulerAngles.y, 0f);
    }

    //gets the horizontal forward vector of the camera
    Vector3 GetCameraForward()
    {
        Vector3 forward = _cameraTransform.forward;
        forward.y = 0f;
        return forward;
    }

    //gets the horizontal right vector of the camera
    Vector3 GetCameraRight()
    {
        Vector3 right = _cameraTransform.right;
        right.y = 0f;
        return right;
    }
}