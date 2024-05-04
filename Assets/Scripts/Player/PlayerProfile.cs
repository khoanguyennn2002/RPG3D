using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    public CharacterStatsManager characterStat { get; private set; }
    public LevelSystem levelSystem { get; private set; }
    private UIController uiController;
    public int PhysicalDamage { get; private set; } 
    public int MagicalDamage { get; private set; }

    private void Start()
    {
        characterStat = GetComponent<CharacterStatsManager>();
        levelSystem = GetComponent<LevelSystem>();
    }
    public void Init()
    {
        UpdateUI();
    }
    public LevelInfo GetCurrentLevel()
    {
        return levelSystem.GetCurrentLevel();
    }
    public void LoadLevel(LevelInfo level, int Xp)
    {
        levelSystem.LoadLevel(level,Xp);
    }
    public int GetCurrentXP()
    {
        return levelSystem.GetCurrentXP();
    }
    public void GainXP(int amount)
    {
        levelSystem.GainXP(amount);
        uiController.SetExpUI(GetCurrentXP());
    }  
    public void IncreaseLevel()
    {
        levelSystem.IncreaseLevel();
        LevelInfo currentLevel = GetCurrentLevel();
        if (currentLevel == null)
        {
            return;
        }
        characterStat.UpdateStats(currentLevel.Level, currentLevel.IncreaseAmount);
        UpdateUI();
       Test();
    }
    public void UpdateUI()
    {
        uiController.UpdateHealthUI(characterStat.Health, characterStat.Health);
        uiController.UpdateManaUI(characterStat.Mana, characterStat.Mana);
        uiController.UpdateExperienceUI(GetCurrentXP(), GetCurrentLevel().XPNeedForNextLevel,GetCurrentLevel().Level);
    }
    public void SetUIController(UIController controller)
    {
        uiController = controller;
    }
    public void Test()
    {
        Debug.Log(characterStat.Health);
        Debug.Log(GetCurrentLevel().Level);
    }    
}