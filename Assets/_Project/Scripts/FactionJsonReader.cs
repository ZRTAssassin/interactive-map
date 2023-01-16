using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FactionJsonReader : MonoBehaviour
{
    [System.Serializable]
    public class jsonFaction
    {
        public string name;
        public string color;
        public string type;
    }

    [System.Serializable]
    public class FactionJsonCollection
    {
        public jsonFaction[] jsonFactions;
        public string collectionName;
    }

    public FactionJsonCollection _jsonCollectionList = new FactionJsonCollection();
    // Start is called before the first frame update
    void Start()
    {
        LoadFromDisk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadFromDisk()
    {
        var file = Application.streamingAssetsPath + "/Factions/" + "factions.json";
        using (var stream = new StreamReader(file))
        {
            string json = stream.ReadToEnd();
            _jsonCollectionList = JsonUtility.FromJson<FactionJsonCollection>(json);

            Debug.Log(_jsonCollectionList.ToString());
        }
        
    }
}
