using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementController : MonoBehaviour
{
    // multi object placement
    // https://www.youtube.com/watch?v=Omu0A4Mk5pE
    
    
    
    // this script needs refactored into a generic script.
    // placeableobject or something, remove the spawning functionality and make the buttons call the functions?
    [SerializeField] bool _newObjectHotkey = false;
    [SerializeField] GameObject _placeableObjectPrefab;
    [SerializeField] GameObject _currentPlaceableObject;
    

    InputHandler _inputs;

    // Start is called before the first frame update
    void Start()
    {
        _inputs = GetComponent<InputHandler>();
        

    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        if (_currentPlaceableObject != null)
        {
            MoveCurrentPlaceableObjectToMouse();
            ReleaseIfClicked();
        }
    }

    void ReleaseIfClicked()
    {
        if (_inputs.LeftClick)
        {
            // Debug.Log("aiopngpaoirngupsgn");
            _currentPlaceableObject = null;
        }
    }

    void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        var hit = Physics2D.GetRayIntersection(ray, 200f);
        if (hit)
        {
//            Debug.Log(hit.point);
             _currentPlaceableObject.transform.position = hit.point;
            // _currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    void GetInputs()
    {
        
        if (_inputs.Number1Triggered)
        {
            _newObjectHotkey = !_newObjectHotkey;
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

    public void SpawnObject(GameObject go)
    {
        HandleObjectSpawning(go);
    }

    void HandleObjectSpawning(GameObject go)
    {
        _newObjectHotkey = !_newObjectHotkey;
        if (_currentPlaceableObject == null)
        {
            _currentPlaceableObject = Instantiate(go);
        }
        else
        {
            Destroy(go);
        }
    }

    void OnEnable()
    {
        
    }
}
