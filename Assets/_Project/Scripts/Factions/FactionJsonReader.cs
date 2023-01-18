using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FactionJsonReader : MonoBehaviour
{
    [System.Serializable]
    public class Faction
    {
        public Faction(string name, string color, string type)
        {
            Name = name;
            Color = color;
            Type = type;
            Id = System.Guid.NewGuid().ToString();
        }

        public string Name;
        public string Color;
        public string Type;
        public string Id;
    }

    [System.Serializable]
    public class FactionJsonCollection
    {
        public List<Faction> factions;
    }


    public FactionJsonCollection _jsonCollectionList = new FactionJsonCollection();

    public void AddFaction(Faction faction)
    {
        _jsonCollectionList.factions.Add(faction);
    }

    void Start()
    {
        LoadFromDisk();
    }

    public void SaveFactions()
    {
        WriteToDisk();
    }

    public void GetFactions()
    {
        LoadFromDisk();
    }

    [ContextMenu("Write to JSON")]
    void WriteToDisk()
    {
        Debug.Log($"{gameObject.name} called WriteToDisk()");
        using (StreamWriter stream =
               new StreamWriter(Application.streamingAssetsPath + "/Factions/" + "factions.json"))
        {
            string json = JsonUtility.ToJson(_jsonCollectionList);
            stream.Write(json);
        }
    }

    void LoadFromDisk()
    {
        var file = Application.streamingAssetsPath + "/Factions/" + "factions.json";
        using (var stream = new StreamReader(file))
        {
            string json = stream.ReadToEnd();
            _jsonCollectionList = JsonUtility.FromJson<FactionJsonCollection>(json);


            Debug.Log($"{gameObject.name} called LoadFromDisk()");
        }
    }
}