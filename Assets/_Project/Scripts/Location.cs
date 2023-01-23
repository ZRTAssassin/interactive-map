using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;


// [RequireComponent(typeof(SpriteRenderer))]
public class Location : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] string _locationName;
    [SerializeField] FactionJsonReader.Faction _currentController;
    [SerializeField] FactionJsonReader _factionJsonReader;

    [SerializeField] string DebugNewOwnerName;

    PlacementController _placementController;


    SpriteShapeRenderer _spriteShapeRenderer;


    public string LocationName => _locationName;
    public FactionJsonReader.Faction CurrentController => _currentController;


    void Awake()
    {
        _locationName = gameObject.name;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _factionJsonReader = FindObjectOfType<FactionJsonReader>();
        _placementController = FindObjectOfType<PlacementController>();
        _spriteShapeRenderer = GetComponent<SpriteShapeRenderer>();
    }

    void OnEnable()
    {
        _placementController.LocationSelectedEvent += OnLocationSelected;
    }

    void OnDisable()
    {
        _placementController.LocationSelectedEvent -= OnLocationSelected;
    }

    void OnLocationSelected(Location location)
    {
        //Debug.Log(location._locationName);
    }

    [ContextMenu("Set New Owner")]
    void SetNewOwner()
    {
        var newOwner = _factionJsonReader._jsonCollectionList.factions.Find((t) => t.Name == DebugNewOwnerName);
        {
            if (newOwner != null)
            {
                NewOwner(newOwner.Name);
            }
        }
    }

    /*void Update()
    {
        if (_currentController != null)
        {
            _spriteRenderer.color = new Color(_currentController.Color.r, _currentController.Color.g,
                _currentController.Color.b, 0.25f);

            Debug.Log("CALLED");
        }
    }*/

    public void NewOwner(string name)
    {
        Debug.Log(name);
        var newOwner = _factionJsonReader._jsonCollectionList.factions.Find((t) => t.Name == name);
        if (newOwner != null)
        {
            // Debug.Log(newOwner.Name);
            _currentController = newOwner;

            
            if (_spriteShapeRenderer != null)
            {
                _spriteShapeRenderer.color = new Color(_currentController.Color.r, _currentController.Color.g,
                    _currentController.Color.b, 0.25f);
            }

            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = new Color(_currentController.Color.r, _currentController.Color.g,
                    _currentController.Color.b, 0.25f);
            }
        }
    }
}