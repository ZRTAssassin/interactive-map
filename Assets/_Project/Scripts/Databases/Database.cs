using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Database : MonoBehaviour
{
    public LocationDatabase Locations;
    public static Database Instance => _instance;
    static Database _instance;


    void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Location GetLocationByName(string name)
    {
        return _instance.Locations.AllLocations.FirstOrDefault(t => t.LocationName == name);
    }

    public static Location GetRandomLocation()
    {
        return _instance.Locations.AllLocations[Random.Range(0, _instance.Locations.AllLocations.Count)];
    }
}
