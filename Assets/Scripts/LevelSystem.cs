using UnityEngine;
public class LevelSystem :MonoBehaviour
{
    public LevelData LevelData;
    [SerializeField] private int CurrentXp;
    private int currentLevel = 1;
    public LevelInfo CurrentLevelInfo => GetCurrentLevel();
    public LevelInfo GetCurrentLevel()
    {
        foreach (var current in LevelData.levels)
        {
            if (currentLevel == current.Level)
            {
              return current;
            }
        }
        return new LevelInfo();
    }
    public void GainXP(int amount)
    {
        CurrentXp += amount;
    }
   
}
