using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonController : MonoBehaviour
{
    [SerializeField] GameObject _buttonPlaceable;

    [SerializeField] List<GameObject> _objects;
    

    // get a button prefab
    // get a reference to all placeable icons (using a script?)
    // add them all to a list
    // loop through and create a button for each placeable object
    // set the properties of the button such as the click, the icon, etc


    // placeable script needs to know what it's going to pass to the button to spawn the object

    void Awake()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            var currentButton = Instantiate(_buttonPlaceable, this.transform);
            var buttonPlaceable = currentButton.GetComponentInChildren<UIButtonPlaceable>();
            buttonPlaceable.SetPrefab(_objects[i]);
        }
    }
}