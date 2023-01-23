using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILocationDisplay : MonoBehaviour
{
    [Space(5f)] [SerializeField] TMP_InputField _inputField;
    [Space(5f)] [SerializeField] TextMeshProUGUI _locationName;
    [Space(5f)] [SerializeField] TextMeshProUGUI _locationOwner;

    [Space(5f)] [SerializeField] PlacementController _placementController;
    [Space(5f)] [SerializeField] Location _currentLocation;

    void Awake()
    {
        _placementController = FindObjectOfType<PlacementController>();
        _locationName.text = "Select a location to view information.";
        _locationOwner.text = String.Empty;
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
        _currentLocation = location;
//         Debug.Log(_currentLocation.CurrentController.Name);
        _locationOwner.text = _currentLocation.CurrentController.Name;
        _locationName.text = _currentLocation.LocationName;
    }

    public void GetNewRandomItem()
    {
        SetUI(Database.GetRandomLocation());
    }

    public void GetItemByID()
    {
        var input = _inputField.text.ToString();
        SetUI(Database.GetLocationByName(input));
    }

    void SetUI(Location location)
    {
        if (location == null)
        {
            _locationName.text = "Incorrect ID.";
            return;
        }

        _locationName.text = location.LocationName;
    }
}