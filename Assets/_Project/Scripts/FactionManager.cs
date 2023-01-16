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
    static List<Faction> _factions = new List<Faction>();

    [SerializeField] GameObject _factionParent;

    public GameObject FactionParent => _factionParent;

    public static FactionManager Instance { get; private set; }
    public List<Faction> GetFactions => _factions.ToList();
    

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

    public void AddFaction(Faction faction)
    {
        _factions.Add(faction);
    }

    public void RemoveFaction(Faction faction)
    {
        _factions.Remove(faction);
    }
}
