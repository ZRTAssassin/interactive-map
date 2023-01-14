using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFaction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] InputField _inputField;

    public void AddFaction()
    {
        var faction = _inputField.text;
        Debug.Log($"faction added, {faction}");    
    }
}
