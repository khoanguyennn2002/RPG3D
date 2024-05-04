using UnityEngine;
public class LevelSystem :MonoBehaviour
{
    public static LevelSystem Instance { get; private set; }

    public LevelData LevelData;
    private int currentXp = 0;
    private int currentLevelIndex = 0;
    public LevelInfo GetCurrentLevel()
    {
        return LevelData.levels[currentLevelIndex];
    }
    public void LoadLevel(LevelInfo level,int Xp)
    {
        var l = LevelData.levels.Find(x => x.Level == level.Level);
        int index = LevelData.levels.IndexOf(l);
        if (index != -1)
        {
            currentLevelIndex = index;
            currentXp = Xp;
        }
    }
    public int GetCurrentXP()
    {
        return currentXp;
    }    
    public void GainXP(int amount)
    {
        currentXp += amount;
    }
    public void IncreaseLevel()
    {
        LevelInfo currentLevel = GetCurrentLevel();
        if(currentLevel == null)
        {
            Debug.Log("khong lay duoc level");
            return;
        }
        if (currentXp >= currentLevel.XPNeedForNextLevel)
        {
            if (currentLevelIndex < LevelData.levels.Count - 1)
            {
                currentLevelIndex++;
                currentXp -= currentLevel.XPNeedForNextLevel;
            }
        }
    }
}
