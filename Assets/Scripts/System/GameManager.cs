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
    public InventorySlot[] Inventory = new InventorySlot[30];
    public InventorySlot[] Equipment = new InventorySlot[8];
}
[Serializable]


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerProfile playerProfile { get; private set; }
    public CharacterCustomize customize { get; private set; }
    public CharacterStatsManager statsManager { get; private set; }
    [SerializeField] private CharacterData characterData;

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
        characterData = new CharacterData();
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
            Array.Copy(player.inventory.GetSlots, characterData.Inventory, player.inventory.GetSlots.Length);
            Array.Copy(player.equipment.GetSlots, characterData.Equipment, player.equipment.GetSlots.Length);
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
        if (characterObject != null)
        {
            var playerInventory = characterObject.GetComponent<Player>().inventory;
            var playerEquipment = characterObject.GetComponent<Player>().equipment;
            LoadInventory(playerInventory);
            LoadEquipment(playerEquipment);
        }
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
    public void LoadInventory(Inventory inventory)
    {
        for (int i = 0; i < characterData.Inventory.Length; i++)
        {
            var item = characterData.Inventory[i].item;
            var amount = characterData.Inventory[i].amount;
            inventory.GetSlots[i].UpdateSlot(item, amount);
        }
    }

    public void LoadEquipment(Inventory equipment)
    {
        for (int i = 0; i < characterData.Equipment.Length; i++)
        {
            var item = characterData.Equipment[i].item;
            var amount = characterData.Equipment[i].amount;
            equipment.GetSlots[i].UpdateSlot(item, amount);
        }
    }
}