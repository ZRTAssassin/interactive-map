using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FactionDiskInterfacer : MonoBehaviour
{
    [SerializeField] bool _usePersistentDataPath = true;

    List<string> _dummyFactions = new List<string> { "Faction 1", "Faction 2", "Faction 3" };
    string _directoryPath;

    void Start()
    {
        // TODO Make this use JSON instead
        if (_usePersistentDataPath)
        {
            _directoryPath = Application.persistentDataPath + "/Factions/";
        }
        else
        {
            _directoryPath = Application.streamingAssetsPath + "/Factions/";
        }

        LoadFactionsFromDirectory();

        UpdateFactionManager();

        SaveCurrentFactionsToDisk();
    }

    void SaveCurrentFactionsToDisk()
    {
        if (_usePersistentDataPath)
        {
            CreateAtPersistentPath();
        }
        else
        {
            CreateAtStreamingAssetsPath();
        }
    }

    void UpdateFactionManager()
    {
        _dummyFactions.Add("New Player Faction-255.123.126.50");

        for (int i = 0; i < 2; i++)
        {
            var components = _dummyFactions[i].Split("-");
            var newObject = new GameObject(components[0]);
            var colorComponents = components[1].Split(".").Select(int.Parse).ToArray();
            newObject.transform.SetParent(FactionManager.Instance.FactionParent.transform);
            newObject.AddComponent<FactionGameobject>();
            newObject.GetComponent<FactionGameobject>()
                .SetColor(
                    colorComponents[0],
                    colorComponents[1],
                    colorComponents[2],
                    colorComponents[3]
                );
        }
        
        /*foreach (var dummyFaction in _dummyFactions)
        {
            var components = dummyFaction.Split("-");
            var newObject = new GameObject(components[0]);
            var colorComponents = components[1].Split(".").Select(int.Parse).ToArray();
            newObject.transform.SetParent(FactionManager.Instance.FactionParent.transform);
            newObject.AddComponent<Faction>();
            newObject.GetComponent<Faction>()
                .SetColor(
                    colorComponents[0],
                    colorComponents[1],
                    colorComponents[2],
                    colorComponents[3]
                );
        }*/
    }

    string PopulateOutputString(List<FactionGameobject> factions)
    {
        string factionOutput = String.Empty;
        foreach (var faction in factions)
        {
            factionOutput = String.Concat(factionOutput, faction.Name + "-" + faction.ColorString + "\n");
//            Debug.Log(factionOutput);
        }

        return factionOutput;
    }

    public void LoadFactionsFromDirectory()
    {
        string filePath = _directoryPath + "factionsInput" + ".txt";
        _dummyFactions = File.ReadAllLines(filePath).ToList();
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
#if UNITY_EDITOR

        AssetDatabase.Refresh();
#endif
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