using DG.Tweening;
using System.Xml.Serialization;
using TMPro;
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
    #endregion
    #region Components
    [SerializeField] private GameObject characterSpot;
    [SerializeField] private GameObject Home;
    [SerializeField] private GameObject NewGame;
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private CharacterCustomize characterCustomize;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private TextMeshProUGUI characterName;
    #endregion
    private void OnEnable()
    {
        btnNewGame.onClick.AddListener(BtnNewGame);
        btnContinue.onClick.AddListener(BtnContinue);
        btnCreate.onClick.AddListener(CreateCharacter);
        btnMale.onClick.AddListener(ChangeMale);
        btnFemale.onClick.AddListener(ChangeFemale);
    }
    private void OnDisable()
    {
        btnNewGame.onClick.RemoveListener(BtnNewGame);
        btnContinue.onClick.RemoveListener(BtnContinue);
        btnCreate.onClick.RemoveListener(CreateCharacter);
        btnMale.onClick.RemoveListener(ChangeMale);
        btnFemale.onClick.RemoveListener(ChangeFemale);
    }
    private void BtnNewGame()
    {
        Home.GetComponent<CanvasGroup>().DOFade(0, 1f)
            .OnComplete(() =>
            {
                fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(
                    () => 
                    {
                        NewGame.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                );
                NewGame.SetActive(true);
                characterSpot.SetActive(true);
                characterCustomize.Initialize();
                Home.GetComponent<CanvasGroup>().blocksRaycasts = false;
            });
    }
    private void BtnContinue()
    {

    }
    private void CreateCharacter()
    {
       GameManager.Instance.SaveCharacter(characterCustomize,characterStats, characterName.text);
       levelLoader.LoadLevel(1);
    }
    private void ChangeFemale()
    {
        characterCustomize.ChangeGender(Gender.Female);
    }
    private void ChangeMale()
    {
        characterCustomize.ChangeGender(Gender.Male);
    }    
    public void ChosseClasses(CharacterStats stats)
    {
        characterStats = stats;
    }
}
