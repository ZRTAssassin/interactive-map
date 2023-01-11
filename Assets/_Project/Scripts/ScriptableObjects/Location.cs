using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Assets/Create New Location")]
public class Location : ScriptableObject
{
    public string _id;
    public string _locationName;
    public Faction _faction;

    [MultiLineProperty]
    public string _locationDescription;
    [MultiLineProperty]
    public string _locationNotableEvents;

    public float _xCoordinate;
    public float _yCoordinate;
    
    
}

public enum Faction
{
    Faction1,
    Faction2,
    Faction3
}
