
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int MaxHealth;
    public int MaxMana;
    public int Strength;
    public int Speed;
    public LevelSystem LevelSystem = new LevelSystem();
}


