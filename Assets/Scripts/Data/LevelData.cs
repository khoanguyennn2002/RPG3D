using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public List<LevelInfo> levels = new List<LevelInfo>();
}

[System.Serializable]
public class LevelInfo
{
    public int Level;
    public int XPNeedForNextLevel;
    public int IncreaseAmount;
}