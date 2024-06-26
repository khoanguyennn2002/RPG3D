using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums 
{
   
}
public enum BodyPart
{
    Hairs = 0,
    HeadAllElements = 1,
    Eyebrow = 2,
    FacialHair = 3,
    Torso = 4,
    Arm_Upper_Right = 5,
    Arm_Upper_Left = 6,
    Arm_Lower_Right = 7,
    Arm_Lower_Left = 8,
    Hand_Right = 9,
    Hand_Left = 10,
    Hips = 11,
    Leg_Right = 12,
    Leg_Left = 13,
}
public enum EquipType
{
    Sword = 100,
    Bow = 101,
    Staff = 102
}
public enum WeaponModeSlot
{
    RightHand,
    LeftHand
}

public enum State
{
    Idle, // 0
    Move, // 1
    Jump, // 2
    Fall, // 3
    Landing //4
}
public enum Stance
{
    Idle = 0,
    IdleCombat = 2,
    TwoHand = 3,
    Spear = 101,
    Axe = 102,
}

public enum Mode
{
    Reset = 0,
    DrawWeapon = 1,
    StoreWeapon = 2,

    PunchRight = 101,
    PunchLeft = 102,
    Kick = 103,

    MeleeRight = 1001
}

public enum ItemType
{
    Food,
    Helmet,
    Weapon,
    Armor,
    Glove,
    Boots,
    Chest,
    Pant,
    Shoulder,
    Back,
    Default
}
public enum Attributes
{
    Strength,
    Agility,
    Intelligence,
    Endurance
}
public enum InterfaceType
{
    Inventory,
    Equipment,
    Chest
}