[System.Serializable]
public class LevelSystem
{
    public int Level;
    public int CurrentXp;
    public int XPNeedForNextLevel;

    public LevelSystem()
    {
        Level = 1;
        CurrentXp = 0;
        XPNeedForNextLevel = 100;
    }
    public LevelSystem(int level, int currentXp, int xpNeedForNextLevel)
    {
        Level = level;
        CurrentXp = currentXp;
        XPNeedForNextLevel = xpNeedForNextLevel;
    }
    public void GainXP(int xpAmount)
    {
        CurrentXp += xpAmount;
        if (CurrentXp >= XPNeedForNextLevel)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        Level++;
        CurrentXp -= XPNeedForNextLevel;
        XPNeedForNextLevel *= 2;
    }
}