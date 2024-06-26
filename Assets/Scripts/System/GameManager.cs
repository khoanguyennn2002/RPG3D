using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class CharacterData
{
    public string Name;
    public Gender Gender;
    public List<string> BodyParts = new List<string>();
    public CharacterStats BaseStats;
    public LevelInfo Level;
    public int CurrentXP;
   // public InventoryData Inventory;
   // public InventoryData Equipment;
}
[Serializable]
public class InventoryData
{
    public InventorySlot[] Slots;

    public InventoryData(Inventory inventory)
    {
        Slots = new InventorySlot[inventory.GetSlots.Length];
        Array.Copy(inventory.GetSlots, Slots, inventory.GetSlots.Length);
    }

    public void ApplyToInventory(Inventory inventory)
    {
        Array.Copy(Slots, inventory.GetSlots, Slots.Length);
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerProfile playerProfile { get; private set; }
    public CharacterCustomize customize { get; private set; }
    public CharacterStatsManager statsManager { get; private set; }
    [SerializeField] private CharacterData characterData = new CharacterData();

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
        statsManager = GetComponent<CharacterStatsManager>();
    }
    public void SaveCharacter()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        characterData.Gender = customize.Gender;
        characterData.BodyParts.Clear();
        foreach (var kvp in customize.BodyParts)
        {
            characterData.BodyParts.Add(kvp.Value?.name);
        }
        characterData.BaseStats = statsManager.GetStatData();
        characterData.Level = playerProfile.GetCurrentLevel();
        characterData.CurrentXP = playerProfile.GetCurrentXP();
        if (player != null)
        {
            characterData.Inventory = new InventoryData(player.inventory);
            characterData.Equipment = new InventoryData(player.equipment);
        }
        SaveToFile(characterData);
    }
    public void LoadCharacter()
    {
        string filePath = Application.dataPath + "/Resources/characterData.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            characterData = JsonUtility.FromJson<CharacterData>(json);
            LoadCharacterFromData();
        }
    }
    private void LoadCharacterFromData()
    {
        var characterObject = GameObject.FindGameObjectWithTag("Player");
        customize.Gender = characterData.Gender;
        var bodyPartsMap = GenerateBodyPartsMap(characterObject);
        for (int i = 0; i < characterData.BodyParts.Count; i++)
        {
            string bodyPartName = characterData.BodyParts[i];
            if (string.IsNullOrEmpty(bodyPartName)) continue;
            if (bodyPartsMap.TryGetValue(bodyPartName, out var bodyPart))
            {
                bodyPart.gameObject.SetActive(true);
                customize.BodyParts[(BodyPart)i] = bodyPart.gameObject;
            }
        }
        var playerInventory = characterObject.GetComponent<Player>().inventory;
        var playerEquipment = characterObject.GetComponent<Player>().equipment;

        characterData.Inventory.ApplyToInventory(playerInventory);
        characterData.Equipment.ApplyToInventory(playerEquipment);
        statsManager.LoadstatData(characterData.BaseStats);
        statsManager.LoadStatsFromData(characterData.Level.IncreaseAmount, characterData.Level.Level);
        playerProfile.LoadLevel(characterData.Level, characterData.CurrentXP);
    }

    private Dictionary<string, Transform> GenerateBodyPartsMap(GameObject characterInstantiate)
    {
        var bodyPartsMap = new Dictionary<string, Transform>();
        foreach (var part in characterInstantiate.GetComponentsInChildren<Transform>(true))
        {
            bodyPartsMap[part.gameObject.name] = part;
        }
        return bodyPartsMap;
    }

    private void SaveToFile(CharacterData data)
    {
        string json = JsonUtility.ToJson(data, true);
        string filePath = Application.dataPath + "/Resources/characterData.json";
        File.WriteAllText(filePath, json);
    }
}