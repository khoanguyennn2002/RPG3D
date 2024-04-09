using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }
    
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
    public void SaveCharacter(CharacterCustomize characterCustomize, CharacterStats characterStats,  string name)
    {
        CharacterData data = CreateCharacterData(characterCustomize, characterStats, name);
        string json = JsonUtility.ToJson(data);
        string filePath = Application.dataPath + "/Resources/characterData.json";
        File.WriteAllText(filePath, json);
    }

    private CharacterData CreateCharacterData(CharacterCustomize characterCustomize, CharacterStats characterStats, string name)
    {
        CharacterData data = new CharacterData();
        data.Gender = characterCustomize.Gender;
        data.Name = name;

        foreach (var kvp in characterCustomize.BodyParts)
        {
            data.BodyParts.Add(kvp.Value?.name);
        }

        data.Stats = characterStats;
        data.level = LevelSystem.Instance.GetCurrentLevel();
        data.currentXP = LevelSystem.Instance.GetCurrentXP();

        return data;
    }

    public void LoadCharacter()
    {
        string filePath = Application.dataPath + "/Resources/characterData.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            CharacterData data = JsonUtility.FromJson<CharacterData>(json);
            GameObject characterObject = GameObject.FindGameObjectWithTag("Player");
            CharacterCustomize characterCustomize = characterObject.GetComponent<CharacterCustomize>();
            CharacterStatsManager statsManager = characterObject.GetComponent<CharacterStatsManager>();
            LevelSystem levelSystem = characterObject.GetComponent<LevelSystem>();
            levelSystem.LoadLevel(data.level,data.currentXP);
            statsManager.LoadStats(data.Stats);
            characterCustomize.Gender = data.Gender;
            Dictionary<string, Transform> bodyPartsMap = GenerateBodyPartsMap(characterObject);

            foreach (string bodyPartName in data.BodyParts)
            {
                if (bodyPartsMap.TryGetValue(bodyPartName, out Transform bodyPart))
                {
                    bodyPart.gameObject.SetActive(true);
                }
            }
        }
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
}