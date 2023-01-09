using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] List<float> _zoomPositions;
    [SerializeField] int _currentZoomLevel;
    [SerializeField] bool _enableLogging;
    CinemachineVirtualCamera _camera;
    Inputs _inputs;
    Vector2 _moveInput;
    bool _zoomIn;
    bool _zoomOut;
    float _zoomInWheel;

    // adapt for zoom https://www.youtube.com/watch?v=5Ue0waWtkY4

    void Awake()
    {
        _inputs = new Inputs();
        transform.position = new Vector3(0, 0, -15);
        
    }

    void Update()
    {
        var currentPos = transform.position;
        
        _moveInput = _inputs.MapControls.Movement.ReadValue<Vector2>();
        _zoomIn = _inputs.MapControls.ZoomIn.triggered;
        _zoomOut = _inputs.MapControls.ZoomOut.triggered;
        _zoomInWheel = _inputs.MapControls.ZoomInWheel.ReadValue<float>();
        // Log($"{_moveInput}");


        transform.position = Vector3.Lerp(transform.position,
            new Vector3(currentPos.x + _moveInput.x * _speed * Time.deltaTime, currentPos.y + _moveInput.y * _speed * Time.deltaTime,
                transform.position.z), 0.5f);

        if (_zoomIn)
        {
            if (_currentZoomLevel < _zoomPositions.Count - 1)
            {
                _currentZoomLevel++;
                _camera.m_Lens.OrthographicSize = _zoomPositions[_currentZoomLevel];

                Log($"{transform.position}, {_camera.m_Lens.OrthographicSize}");
            }
            else
            {
                _currentZoomLevel = _zoomPositions.Count - 1;
            }
        }

        if (_zoomOut)
        {
            if (_currentZoomLevel >= 1)
            {
                _currentZoomLevel--;
                _camera.m_Lens.OrthographicSize = _zoomPositions[_currentZoomLevel];
                Log($"{transform.position}, {_camera.m_Lens.OrthographicSize}");
            }
            else
            {
                _currentZoomLevel = 0;

            }
            
        }
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