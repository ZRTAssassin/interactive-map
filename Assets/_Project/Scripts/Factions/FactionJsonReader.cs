using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FactionJsonReader : MonoBehaviour
{
    [System.Serializable]
    public class Faction
    {
        public string name;
        public string color;
        public string type;
    }

    [System.Serializable]
    public class FactionJsonCollection
    {
        public Faction[] factions;
        public string collectionName;
    }

    public FactionJsonCollection _jsonCollectionList = new FactionJsonCollection();


    // Start is called before the first frame update
    void Start()
    {
        LoadFromDisk();
        WriteToDisk();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void WriteToDisk()
    {
        Faction[] factions = new Faction[_jsonCollectionList.factions.Length];
        /*for (int i = 0; i < _jsonCollectionList.factions.Length; i++)
        {
            Debug.Log(_jsonCollectionList.factions[i].name);
        }*/

        for (int i = 0; i < factions.Length; i++)
        {
            factions[i] = new Faction
            {
                name = _jsonCollectionList.factions[i].name, color = _jsonCollectionList.factions[i].color,
                type = _jsonCollectionList.factions[i].type
            };
            Debug.Log(factions[i].name);
        }

        _jsonCollectionList = new FactionJsonCollection() { factions = factions, collectionName = "factions" };

        using (StreamWriter stream =
               new StreamWriter(Application.streamingAssetsPath + "/Factions/" + "factions2.json"))
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