using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Space(10f)] [Header("Debug")] [SerializeField]
    bool _enableLogging;

    [Space(10f), Header("Camera Setup")] [SerializeField]
    CinemachineVirtualCamera _camera;
    [SerializeField] Vector2 _minVector;
    [SerializeField] Vector2 _maxVector;
    [SerializeField] int _cameraDistance;
    [SerializeField] List<float> _cameraDistances;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _zoomInMax;
    [SerializeField] float _zoomOutMax;

    Inputs _inputs;
    Vector2 _moveInput;
    bool _zoomIn;
    bool _zoomOut;
    float _zoomInWheel;


    // adapt for zoom https://www.youtube.com/watch?v=5Ue0waWtkY4

    void Awake()
    {
        _inputs = new Inputs();
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        GetInput();
        HandleMove();
        HandleZoom();
    }

    void HandleZoom()
    {
        if (_zoomIn)
        {
            if (_cameraDistance < _cameraDistances.Count - 1)
            {
                _cameraDistance++;
                _camera.m_Lens.OrthographicSize = _cameraDistances[_cameraDistance];
                // _camera.m_Lens.OrthographicSize = _cameraDistances[_currentCameraDistance];

                Log($"{transform.position}, {_camera.m_Lens.OrthographicSize}");
            }
            else
            {
                _cameraDistance = _cameraDistances.Count - 1;
            }
        }

        if (_zoomOut)
        {
            if (_cameraDistance >= 1)
            {
                _cameraDistance--;
                _camera.m_Lens.OrthographicSize = _cameraDistances[_cameraDistance];
                Log($"{transform.position}, {_camera.m_Lens.OrthographicSize}");
            }
            else
            {
                _cameraDistance = 0;
            }
        }
    }

    void HandleMove()
    {
        var currentPos = transform.position;
        var newDirection = new Vector3(currentPos.x + _moveInput.x * _moveSpeed * Time.deltaTime,
            currentPos.y + _moveInput.y * _moveSpeed * Time.deltaTime,
            transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newDirection, 1);

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

    void GetInput()
    {
        _moveInput = _inputs.MapControls.Movement.ReadValue<Vector2>();
        _zoomIn = _inputs.MapControls.ZoomIn.triggered;
        _zoomOut = _inputs.MapControls.ZoomOut.triggered;
        _zoomInWheel = _inputs.MapControls.ZoomInWheel.ReadValue<float>();
        // Log($"{_moveInput}");
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
    }

    void OnDisable()
    {
        _inputs.MapControls.Disable();
    }
}