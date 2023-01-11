using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour, ITogglable
{
    // video on panel manager
    // https://www.youtube.com/watch?v=texonivDsy0
    [SerializeField] bool _isActive;

    void Awake()
    {
        _isActive = false;
    }

    public void Toggle()
    {
        // use a bool for state
        // when bool is checked, turn on panel
        // when bool is unchecked, turn off panel
    }
}

public interface ITogglable
{
    public void Toggle();
}
