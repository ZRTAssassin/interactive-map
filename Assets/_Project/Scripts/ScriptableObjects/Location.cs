
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Assets/Create New Location")]
public class Location : ScriptableObject
{
    public string _id;
    public string _locationName;
    [MultiLineProperty]
    public string _locationDescription;
    [MultiLineProperty]
    public string _notableEvents;

    public float _xCoordinate;
    public float _yCoordinate;

}
