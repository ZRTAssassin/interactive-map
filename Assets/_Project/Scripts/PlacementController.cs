using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementController : MonoBehaviour
{
    [SerializeField] GameObject _placeableObjectPrefab;
    [SerializeField] bool _newObjectHotkey;
    [SerializeField] GameObject _currentPlaceableObject;

    Inputs _inputs;

    // Start is called before the first frame update
    void Awake()
    {
        _inputs = new Inputs();

    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        if (_currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToMouse();
        }
    }

    void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log(hitInfo.point);
            _currentPlaceableObject.transform.position = hitInfo.point;
            _currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    void GetInputs()
    {
        if (_newObjectHotkey)
        {
            if (_currentPlaceableObject == null)
            {
                _currentPlaceableObject = Instantiate(_placeableObjectPrefab);
            }
            else
            {
                Destroy(_currentPlaceableObject);
            }
        }
    }
    void OnNumber1Started(InputAction.CallbackContext context)
    {
        if (context.started)
            _newObjectHotkey = true;
    }
    void OnNumber1Cancelled(InputAction.CallbackContext context)
    {
        if (context.canceled)
            _newObjectHotkey = false;
    }
    void OnEnable()
    {
        _inputs.MapControls.Enable();
        _inputs.MapControls.Number1.started += OnNumber1Started;
        _inputs.MapControls.Number1.canceled += OnNumber1Cancelled;
    }


    void OnDisable()
    {
        _inputs.MapControls.Disable();
        _inputs.MapControls.Number1.started -= OnNumber1Started;
        _inputs.MapControls.Number1.canceled -= OnNumber1Cancelled;
    }


}
