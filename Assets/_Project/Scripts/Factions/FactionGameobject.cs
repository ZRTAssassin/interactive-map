using System;
using UnityEngine;

public class FactionGameobject : MonoBehaviour
{
    /*
     public Faction (string name)
    {
        Name = name;
    }
    */
    
    // Faction is what? Name, Color.
    // Locations need Name, Faction,

    [SerializeField] string _name;
    [SerializeField] Color _color;

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetColor(int r, int g, int b, int a)
    {
        _color.r = r;
        _color.g = g;
        _color.b = b;
        _color.a = a;
    }

    public string Name => _name;
    public Color Color => _color;
    public string ColorString => FormatColorString();

    string FormatColorString()
    {
        
        return $"{_color.r}.{_color.g}.{_color.b}.{_color.a}";
    }


    void Awake()
    {
        SetName(gameObject.name);
        FactionManager.Instance.AddFaction(this);
    }
}