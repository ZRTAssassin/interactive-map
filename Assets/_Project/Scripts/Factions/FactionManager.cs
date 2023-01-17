using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactionManager : MonoBehaviour
{
    // import factions from a text file into a list/array
    // use custom property drawer to display in a popup/dropdown style in inspector. (https://www.youtube.com/watch?v=ThcSHbVh7xc)
    // ditch enum

    [SerializeField]
    static List<FactionGameobject> _factions = new List<FactionGameobject>();

    [SerializeField] GameObject _factionParent;

    public GameObject FactionParent => _factionParent;

    public static FactionManager Instance { get; private set; }
    public List<FactionGameobject> GetFactions => _factions.ToList();
    

    void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // StartCoroutine(DisplayFactions());
        // Debug.Log(_factions.Count);
    }


    IEnumerator DisplayFactions()
    {
        yield return new WaitForSeconds(2);
        foreach (var faction in _factions)
        {
            // Debug.Log(faction.Name);
        }
    }

    public void AddFaction(FactionGameobject factionGameobject)
    {
        _factions.Add(factionGameobject);
    }

    public void RemoveFaction(FactionGameobject factionGameobject)
    {
        _factions.Remove(factionGameobject);
    }
}
