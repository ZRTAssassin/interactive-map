using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FactionDiskInterfacer : MonoBehaviour
{

    List<string> _dummyFactions = new List<string> { "Faction 1", "Faction 2", "Faction 3" };
    string _directoryPath;
    void Start()
    {
        _directoryPath = Application.persistentDataPath + "/Factions/";
        LoadFactionsFromDirectory();
        _dummyFactions.Add("New Player Faction");

//        var factionOutput = PopulateOutputString();
        // CreateAtStreamingAssetsPath();
        CreateAtPersistentPath();
        
//        Debug.Log(Application.persistentDataPath);
    }

    string PopulateOutputString(List<Faction> factions)
    {
        string factionOutput = String.Empty;
        foreach (var faction in factions)
        {
            factionOutput = String.Concat(factionOutput, faction.Name + "\n");
//            Debug.Log(factionOutput);
        }

        return factionOutput;
    }

    public void LoadFactionsFromDirectory()
    {
        string filePath =  _directoryPath + "factionsInput" + ".txt";
        _dummyFactions = File.ReadAllLines(filePath).ToList();
        
        foreach (var dummyFaction in _dummyFactions)
        {
            Faction newFaction = new Faction(dummyFaction);
            FactionManager.Instance.AddFaction(newFaction);
            
        }
    }

    public void CreateAtStreamingAssetsPath()
    {
        var currentFactions = PopulateOutputString(FactionManager.Instance.GetFactions);
        string docName = Application.streamingAssetsPath + "/Factions/" + "factionsOutput" + ".txt";
        
        if (!File.Exists(docName))
        {
            File.WriteAllText(docName, "Created new Factions list \n \n");
        }
        File.AppendAllText(docName, currentFactions + "\n");
    }

    [ContextMenu("Create at persistant location")]
    public void CreateAtPersistentPath()
    {
        var currentFactions = PopulateOutputString(FactionManager.Instance.GetFactions);
        
        if (!Directory.Exists(Application.persistentDataPath + "/Factions/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Factions/");
        }
        string docName2 = Application.persistentDataPath + "/Factions/" + "factionsOutput" + ".txt";
        if (!File.Exists(docName2))
        {
            File.WriteAllText(docName2, "Created new Factions list \n \n");
        }
        File.AppendAllText(docName2, currentFactions + "\n");
    }
}
