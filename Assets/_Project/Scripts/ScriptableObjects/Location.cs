using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


public class Location : MonoBehaviour
{
    public string _id;
    public string _locationName;
    [ValueDropdown("Factions")]
    public List<Faction> Factions = FactionManager.Instance.GetFactions;

    [MultiLineProperty]
    public string _locationDescription;
    [MultiLineProperty]
    public string _locationNotableEvents;

    public float _xCoordinate;
    public float _yCoordinate;
    
    
}