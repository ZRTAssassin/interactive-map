using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Placeable : MonoBehaviour
{
    [SerializeField] Sprite _sprite;

    public Sprite Sprite => _sprite;
    
}
