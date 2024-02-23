
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public List<Attribute> attributes;
}

[System.Serializable]
public class Attribute
{
    public string Name;
    public int Value;
    public string Description;

    //public Attribute(string name, int value, string description)
    //{
    //    Name = name;
    //    Value = value;
    //    Description = description;
    //}
}
