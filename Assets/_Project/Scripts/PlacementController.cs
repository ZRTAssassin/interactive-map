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
    [SerializeField] Placeable _currentSelectedObject;

    [SerializeField] LayerMask _layerMask;

    public event Action<Location> LocationSelectedEvent = delegate { };


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
            DeleteIfRightClicked();
        }
    }

    void DeleteIfRightClicked()
    {
        if (_inputs.RightClick)
        {
            Destroy(_currentPlaceableObject);
        }
    }

    void ReleaseIfClicked()
    {
        if (_inputs.LeftClick && !_inputs.LeftShift)
        {
            // Debug.Log("aiopngpaoirngupsgn");
            _currentPlaceableObject.GetComponent<LineRenderer>().enabled = false;
            _currentPlaceableObject = null;
            _currentSelectedObject = null;
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
        if (_inputs.LeftShift && _inputs.LeftClick)
        {
            if (_currentPlaceableObject == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                var hit = Physics2D.GetRayIntersection(ray, 200f, _layerMask);

                if (hit)
                {
                    _currentSelectedObject = hit.transform.gameObject.GetComponent<Placeable>();
                }

                if (_currentSelectedObject != null)
                {
                    // Debug.Log(hit.collider.gameObject.name);
                    var lineRenderer = _currentSelectedObject.GetComponent<LineRenderer>();
                    _currentPlaceableObject = _currentSelectedObject.gameObject;
                    if (lineRenderer != null)
                    {
                        lineRenderer.enabled = true;
                    }
                }
            }
        }

        if (_inputs.LeftClick && _currentPlaceableObject == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            var hit = Physics2D.GetRayIntersection(ray, 200f, _layerMask);
            if (hit)
            {
                var location = hit.collider.GetComponent<Location>();
                if (location != null)
                {
                    LocationSelectedEvent(location);
                    location.NewOwner("The Billhooks");
                }
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