
using UnityEngine;
public enum HeroClass
{
    Sword,
    Archer,
    Mage
}
[CreateAssetMenu]
public class CharacterStats : ScriptableObject
{

    public int BaseHealth;
    public int BaseMana;
    public HeroClass type;
    [Space(20)]
    public int Strength;
    public int Agility;
    public int Intelligence;
    public int Endurance;
    private void OnValidate()
    {
        BaseHealth = 100 + (Endurance * 10);
        BaseMana = 100 + (Intelligence * 10);
        //switch(type)
        //{
        //    case HeroClass.Sword:
        //        BaseHealth = 100 + (Endurance * 10);
        //        BaseMana = 50 + (Intelligence * 10);
        //        break;
        //    case HeroClass.Archer:
        //        BaseHealth = 100 + (Endurance * 10);
        //        BaseMana = 80 + (Intelligence * 10);
        //        break;
        //    case HeroClass.Mage:
        //        BaseHealth = 100 + (Endurance * 10);
        //        BaseMana = 100 + (Intelligence * 10);
        //        break;
        //}    
    }
}