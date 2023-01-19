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
            Type = type;
            Id = System.Guid.NewGuid().ToString();
            ColorString = color;
        }

        public string Name;
        public Color Color;
        public string Type;
        public string Id;
        public string ColorString;

        
        public int HexToDecimal(string hex)
        {
            int decimalNum = System.Convert.ToInt32(hex, 16);
            return decimalNum;
        }

        public string DecToHex(int value)
        {
            return value.ToString("X2");
        }

        string FloatNormalizedToHex(float value)
        {
            return DecToHex(Mathf.RoundToInt(value * 255));
        }

        float HexToFloatNormalized(string hex)
        {
            return HexToDecimal(hex) / 255f;
        }

        public Color GetColorFromString(string hexString)
        {
            float red = HexToFloatNormalized(hexString.Substring(0, 2));
            float green = HexToFloatNormalized(hexString.Substring(2, 2));
            float blue = HexToFloatNormalized(hexString.Substring(4, 2));
            return new Color(red, green, blue);
        }

        public string GetStringFromColor(Color color)
        {
            string red = FloatNormalizedToHex(color.r);
            string green = FloatNormalizedToHex(color.g);
            string blue = FloatNormalizedToHex(color.b);
            return $"{red}{green}{blue}";
        }
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
        GetFactions();
    }

    public void SaveFactions()
    {
        WriteToDisk();
    }

    public void GetFactions()
    {
        LoadFromDisk();
        foreach (var faction in _jsonCollectionList.factions)
        {
            faction.Color = faction.GetColorFromString(faction.ColorString);
        }
    }

    [ContextMenu("Write to JSON")]
    void WriteToDisk()
    {
        Debug.Log($"{gameObject.name} called WriteToDisk()");
        // maybe loop through collection and convert color to hex?
        for (int i = 0; i < _jsonCollectionList.factions.Count; i++)
        {
            _jsonCollectionList.factions[i].ColorString = 
                _jsonCollectionList.factions[i].GetStringFromColor(_jsonCollectionList.factions[i].Color);
        }
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