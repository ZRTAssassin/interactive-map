using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILocationDisplay : MonoBehaviour
{
    [Space(5f)] [SerializeField] TMP_InputField _inputField;
    [Space(5f)] [SerializeField] TextMeshProUGUI _locationName;
    [Space(5f)] [SerializeField] TextMeshProUGUI _locationDescription;
    [Space(5f)] [SerializeField] TextMeshProUGUI _locationNotableEvents;

    [Space(5f)] int _itemID;

    public void GetNewRandomItem()
    {
        SetUI(Database.GetRandomLocation());
    }

    public void GetItemByID()
    {
        var input = _inputField.text.ToString();
        SetUI(Database.GetLocationByID(input));
    }

    void SetUI(Location location)
    {
        if (location == null)
        {
            _locationName.text = "Incorrect ID.";
            _locationDescription.text = String.Empty;
            _locationNotableEvents.text = String.Empty;
            return;
        }
        _locationName.text = location._locationName;
        _locationDescription.text = location._locationDescription;
        _locationNotableEvents.text = location._locationNotableEvents;
        
    }
}

