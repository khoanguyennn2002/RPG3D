using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;
    public int Health { get; private set; }
    public int Mana { get; private set; }
    public int Strength { get; private set; }
    public int Agility { get; private set; }
    public int Intelligence { get; private set; }
    public int Endurance { get; private set; }

    //private void Start()
    //{
    //    Initialize();
    //}

    public void Initialize()
    {
        Health = characterStats.BaseHealth;
        Mana = characterStats.BaseMana;
        Strength = characterStats.Strength;
        Agility = characterStats.Agility;
        Intelligence = characterStats.Intelligence;
        Endurance = characterStats.Endurance;
    }

    public void LoadStats(CharacterStats newStats)
    {
        characterStats = newStats;
        Initialize();
    }    

    public void UpdateStats(int level, int amount)
    {

        int statIncreaseAmount = level * amount;

        Health += statIncreaseAmount;
        Mana += statIncreaseAmount;
        Strength += statIncreaseAmount;
        Agility += statIncreaseAmount;
        Intelligence += statIncreaseAmount;
        Endurance += statIncreaseAmount;
    }
}
