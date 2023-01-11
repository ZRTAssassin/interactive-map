using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    // video on panel manager
    // https://www.youtube.com/watch?v=texonivDsy0
    [SerializeField] bool _isActive;

    void Awake()
    {
        _isActive = false;
    }
    
}


