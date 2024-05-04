using System.Collections.Generic;

public class CharacterData 
{
    public string Name;
    public Gender Gender;
    public List<string> BodyParts = new List<string>();
    public CharacterStats Stats;
    public LevelInfo level;
    public int currentXP;
}
