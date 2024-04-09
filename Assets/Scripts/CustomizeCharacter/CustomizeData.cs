using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterData 
{
    public string Name;
    public Gender Gender;
    public List<string> BodyParts = new List<string>();
    public CharacterStats Stats;
    public LevelInfo level;
    public int currentXP;
}
