using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Database : MonoBehaviour
{
    public LocationDatabase _locations;
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

    public static Location GetLocationByID(string id)
    {
        return _instance._locations._allLocations.FirstOrDefault(t => t._id == id);
        
        foreach (var location in _instance._locations._allLocations)
        {
            if (location._id == id)
            {
                return location;
            }
        }

        return null;
    }

    public static Location GetRandomLocation()
    {
        return _instance._locations._allLocations[Random.Range(0, _instance._locations._allLocations.Count())];
    }
}
