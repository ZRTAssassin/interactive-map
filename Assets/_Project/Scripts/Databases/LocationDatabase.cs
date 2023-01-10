using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Location Database", menuName = "Assets/New Location Database")]
public class LocationDatabase : ScriptableObject
{
    // https://www.youtube.com/watch?v=yo80rh7K-2k
    public List<Location> _allLocations;
}
