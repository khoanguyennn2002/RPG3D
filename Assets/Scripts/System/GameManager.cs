using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }
     public PlayerProfile playerProfile { get; private set; }
     public CharacterCustomize customize { get; private set; }
    private CharacterData characterData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        playerProfile = GetComponent<PlayerProfile>();
        customize = GetComponent<CharacterCustomize>();
        characterData = new CharacterData();
    }
    public void SaveCharacter()
    {
        PopulateCharacterData();
        string json = JsonUtility.ToJson(characterData);
        string filePath = Application.dataPath + "/Resources/characterData.json";
        File.WriteAllText(filePath, json);
        SaveStats();
    }

    private void PopulateCharacterData()
    {
        CharacterStatsManager stat = gameObject.GetComponent<CharacterStatsManager>();
        characterData.Gender = customize.Gender;
        foreach (var kvp in customize.BodyParts)
        {
            characterData.BodyParts.Add(kvp.Value?.name);
        }
        characterData.Stats = stat.GetStatData();
        characterData.level = playerProfile.GetCurrentLevel();
        characterData.currentXP = playerProfile.GetCurrentXP();
    }    

    public void LoadCharacter()
    {
        string filePath = Application.dataPath + "/Resources/characterData.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            characterData = JsonUtility.FromJson<CharacterData>(json);
            SetCharacterFromData();
        }
    }
    private void SetCharacterFromData()
    {
        GameObject characterObject = GameObject.FindGameObjectWithTag("Player");

        CharacterStatsManager statsManager = GetComponent<CharacterStatsManager>();
        customize.BuildLists();
        customize.Gender = characterData.Gender;

        Dictionary<string, Transform> bodyPartsMap = GenerateBodyPartsMap(characterObject);
        for (int i = 0; i < characterData.BodyParts.Count; i++)
        {
            string bodyPartName = characterData.BodyParts[i];
            if (bodyPartName == "")
            {
                continue;
            }
            if (bodyPartsMap.TryGetValue(bodyPartName, out Transform bodyPart))
            {
                bodyPart.gameObject.SetActive(true);
                customize.BodyParts[(BodyPart)i] = bodyPart.gameObject;
            }
        }
        statsManager.SetstatData(characterData.Stats);
        statsManager.Initialize();

        playerProfile.LoadLevel(characterData.level, characterData.currentXP);
    }    
    private Dictionary<string, Transform> GenerateBodyPartsMap(GameObject characterInstantiate)
    {
        Dictionary<string, Transform> bodyPartsMap = new Dictionary<string, Transform>();

        foreach (Transform part in characterInstantiate.GetComponentsInChildren<Transform>(true))
        {
            bodyPartsMap.Add(part.gameObject.name, part);
        }
        return bodyPartsMap;
    }
    private void SaveStats()
    {
        CharacterStatsManager statsManager = GetComponent<CharacterStatsManager>();

        CharacterStats statsData = new CharacterStats();    

        statsData.BaseHealth = statsManager.Health;
        statsData.BaseMana = statsManager.Mana;
        statsData.Strength = statsManager.Strength;
        statsData.Agility = statsManager.Agility;
        statsData.Intelligence = statsManager.Intelligence;
        statsData.Endurance = statsManager.Endurance;

        string json = JsonUtility.ToJson(statsData);    
        string filePath = Application.dataPath + "/Resources/statsData.json";

        File.WriteAllText(filePath, json);
    }
}