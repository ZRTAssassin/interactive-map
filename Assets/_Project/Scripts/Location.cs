using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class Location : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] string _locationName;
    [SerializeField] FactionJsonReader.Faction _currentController;

    [SerializeField] FactionJsonReader _factionJsonReader;


    public string LocationName => _locationName;


    void Awake()
    {
        _locationName = gameObject.name;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _factionJsonReader = FindObjectOfType<FactionJsonReader>();
    }

    void Update()
    {
        if (_currentController != null)
        {
            _spriteRenderer.color = new Color(_currentController.Color.r, _currentController.Color.g,
                _currentController.Color.b, 0.25f);

            Debug.Log("CALLED");
        }
    }

    public void NewOwner(string name)
    {
        var newOwner = _factionJsonReader._jsonCollectionList.factions.Find((t) => t.Name == name);
        if (newOwner != null)
        {
            Debug.Log(newOwner.Name);
            _currentController = newOwner;
        }
    }
}