
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

    public void Initialize()
    {
        Health = characterStats.BaseHealth;
        Mana = characterStats.BaseMana;
        Strength = characterStats.Strength;
        Agility = characterStats.Agility;
        Intelligence = characterStats.Intelligence;
        Endurance = characterStats.Endurance;
    }

    public void SetstatData(CharacterStats newStats)
    {
        characterStats = newStats;
    }
    public void UpdateStats(int level, int amount)
    {
        int statIncreaseAmount = level * amount;

        Strength += statIncreaseAmount;
        Agility += statIncreaseAmount;
        Intelligence += statIncreaseAmount;
        Endurance += 10;
        Health = 100 + (Endurance * 10);
        Mana = 100 + (Intelligence * 10);
    }
    public CharacterStats GetStatData()
    {
        return characterStats;
    }

}
