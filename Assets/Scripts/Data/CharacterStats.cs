using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStats : ScriptableObject
{
    public int BaseHealth;
    public int BaseMana;

    public int Strength;
    public int Agility;
    public int Intelligence;
    public int Endurance;
}