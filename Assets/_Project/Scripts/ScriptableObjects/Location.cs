using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Location : MonoBehaviour
{

    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] string _locationName;
    [SerializeField] Faction _currentController;
    [MultiLineProperty] string _locationDescription;
    [MultiLineProperty] string _locationNotableEvents;

    
    public string LocationName => _locationName;
    public string LocationDescription => LocationDescription;
    public string LocationNotableEvents => _locationNotableEvents;

    public float _xCoordinate;
    public float _yCoordinate;

    void Awake()
    {
        _locationName = gameObject.name;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_currentController != null)
        {
            _spriteRenderer.color =_currentController.Color;
            Debug.Log("CALLED");
        }
    }
}