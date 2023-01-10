
using UnityEngine;
using UnityEditor;
using System.IO;

public class CSVtoSO
{
    // https://www.youtube.com/watch?v=1EdLTF43d70
    static string locationCSVPath = "/Editor/CSVs/LocationCSV.csv";
    
    [MenuItem("Utilities/Generate Location Data")]
    public static void GenerateLocationData()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + locationCSVPath);
        
        foreach (var line in allLines)
        {
            string[] splitData = line.Split(",");
            if (splitData.Length != 4)
            {
                Debug.Log("ISSUE");
                return;
            }
            Location location = ScriptableObject.CreateInstance<Location>();
            //cast to correct data type if need location._id = splitData[i];
            
            AssetDatabase.CreateAsset(location, $"Assets/_Project/Scripts/ScriptableObjects/{location._locationName}.asset");
        }
        AssetDatabase.SaveAssets();

    }
}
