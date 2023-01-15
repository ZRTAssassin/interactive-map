using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class UIButtonPlaceable : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _text;

    [SerializeField] GameObject _prefab;

    [SerializeField] PlacementController _placementController;

    void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        var placeable = _prefab.GetComponent<Placeable>();
        if (placeable != null)
        {
            _image.sprite = placeable.Sprite;
            _image.type = Image.Type.Simple;
            _text.text = String.Empty;
        }

        _placementController = FindObjectOfType<PlacementController>();
        _button.onClick.AddListener(() => _placementController.SpawnObject(_prefab));
    }

    public void SetPrefab(GameObject prefab)
    {
        _prefab = prefab;
    }
}