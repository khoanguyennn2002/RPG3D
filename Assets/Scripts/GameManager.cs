using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }
    [SerializeField] private CharacterData characterData;
    [SerializeField] private LevelSystem LevelSystem;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
       
    }
    public void SaveCharacter(CharacterCustomize characterCustomize)
    {
        
    }
}

