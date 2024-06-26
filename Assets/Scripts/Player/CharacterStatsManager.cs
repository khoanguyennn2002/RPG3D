
using UnityEngine;
public class CharacterStatsManager : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;

    [SerializeField] private int health;
    [SerializeField] private int mana;
    [SerializeField] private int strength;
    [SerializeField] private int agility;
    [SerializeField] private int intelligence;
    [SerializeField] private int endurance;

    public string Name { get ; set; }
    public int Health { get { return health; } set { health = value; } }
    public int Mana { get { return mana; } set { mana = value; } }
    public int Strength { get { return strength; } set { strength = value; } }
    public int Agility { get { return agility; } set { agility = value; } }
    public int Intelligence { get { return intelligence; } set { intelligence = value; } }
    public int Endurance { get { return endurance; } set { endurance = value; } }

    public void Initialize()
    {
        Health = characterStats.BaseHealth;
        Mana = characterStats.BaseMana;
        Strength = characterStats.Strength;
        Agility = characterStats.Agility;
        Intelligence = characterStats.Intelligence;
        Endurance = characterStats.Endurance;
    }

    public void LoadstatData(CharacterStats newStats)
    {
        characterStats = newStats;
        Initialize();
    }
    public void LoadStatsFromData( int statIncreaseAmount, int level)
    {
        int amout = statIncreaseAmount * (level - 1);
        Strength += amout;
        Agility += amout;
        Intelligence += amout;
        Endurance += amout;
        Health = 100 + (Endurance * 10);
        Mana = 100 + (Intelligence * 10);
      
    }
    public void UpdateStats(int statIncreaseAmount)
    {
        Strength += statIncreaseAmount;
        Agility += statIncreaseAmount;
        Intelligence += statIncreaseAmount;
        Endurance += statIncreaseAmount;
        Health = 100 + (Endurance * 10);
        Mana = 100 + (Intelligence * 10);
        Debug.Log(Strength);
    }    
    public CharacterStats GetStatData()
    {
        return characterStats;
    }
    public void ApplyItemBuffs(Item item)
    {
        foreach (ItemBuff buff in item.buffs)
        {
            switch (buff.attribute)
            {
                case Attributes.Strength:
                    Strength += buff.value;
                    break;
                case Attributes.Agility:
                    Agility += buff.value;
                    break;
                case Attributes.Intelligence:
                    Intelligence += buff.value;
                    break;
                case Attributes.Endurance:
                    Endurance += buff.value;
                    break;
                default:
                    break;
            }
        }
        Health = 100 + (Endurance * 10);
        Mana = 100 + (Intelligence * 10);
    }
    public void RemoveBuff(Item item)
    {
        foreach (ItemBuff buff in item.buffs)
        {
            switch (buff.attribute)
            {
                case Attributes.Strength:
                    Strength -= buff.value;
                    break;
                case Attributes.Agility:
                    Agility -= buff.value;
                    break;
                case Attributes.Intelligence:
                    Intelligence -= buff.value;
                    break;
                case Attributes.Endurance:
                    Endurance -= buff.value;
                    break;
                default:
                    break;
            }
        }
        Health = 100 + (Endurance * 10);
        Mana = 100 + (Intelligence * 10);
    }
}
