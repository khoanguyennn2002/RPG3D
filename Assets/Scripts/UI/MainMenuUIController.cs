using DG.Tweening;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    #region Button
    [SerializeField] private Button btnNewGame;
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnCreate;
    [SerializeField] private Button btnMale;
    [SerializeField] private Button btnFemale;
    [SerializeField] private Button btnQuit;
    #endregion
    #region Components
    [SerializeField] private GameObject characterSpot;
    [SerializeField] private GameObject Home;
    [SerializeField] private GameObject NewGame;
    [SerializeField] private CharacterCustomize characterCustomize;
    [SerializeField] private CharacterStatsManager characterStats;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private TextMeshProUGUI characterName;

    [SerializeField] private TMP_Text hairStyle;
    [SerializeField] private TMP_Text eyeStyle;
    [SerializeField] private TMP_Text beardStyle;
    [SerializeField] private TMP_Text faceStyle;
    #endregion
    private void OnEnable()
    {
        btnNewGame.onClick.AddListener(BtnNewGame);
        btnContinue.onClick.AddListener(BtnContinue);
        btnCreate.onClick.AddListener(CreateCharacter);
        //btnMale.onClick.AddListener(ChangeMale);
        //btnFemale.onClick.AddListener(ChangeFemale);
    }
    private void OnDisable()
    {
        btnNewGame.onClick.RemoveListener(BtnNewGame);
        btnContinue.onClick.RemoveListener(BtnContinue);
        btnCreate.onClick.RemoveListener(CreateCharacter);
        //btnMale.onClick.RemoveListener(ChangeMale);
        //btnFemale.onClick.RemoveListener(ChangeFemale);
    }
    private void BtnNewGame()
    {
        Home.GetComponent<CanvasGroup>().DOFade(0, 0.75f)
            .OnComplete(() =>
            {
                NewGame.GetComponent<CanvasGroup>().DOFade(1, 0.75f)
                .OnComplete(() =>
                {
                characterCustomize.BuildLists();
                characterCustomize.Initialize();
                NewGame.GetComponent<CanvasGroup>().blocksRaycasts = true;
                });
                    
                Home.GetComponent<CanvasGroup>().blocksRaycasts = false;
            });
    }
    private void BtnContinue()
    {
        Destroy(characterSpot);
        levelLoader.LoadLevel(1);
    }
    private void CreateCharacter()
    {
       GameManager.Instance.SaveCharacter();
       Destroy(characterSpot);
       levelLoader.LoadLevel(1);
    }
    public void ChosseClasses(CharacterStats stats)
    {
        characterStats.LoadstatData(stats);
    }
    public void ExitGame()
    {
        Application.Quit();
    }    
}
