using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    [SerializeField] private Button btnNewGame;
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnCreate;
    [SerializeField] private Button btnTest;
    [SerializeField] private GameObject characterSpot;
    [SerializeField] private GameObject characterPrefab; // Change from GameObject to GameObject Prefab
    [SerializeField] private GameObject Home;
    [SerializeField] private GameObject NewGame;
    private GameObject characterInstance; // Change from GameObject to GameObject
    public CharacterCustomize characterCustomize;
    private void OnEnable()
    {
        btnNewGame.onClick.AddListener(BtnNewGame);
        btnContinue.onClick.AddListener(BtnContinue);
        btnCreate.onClick.AddListener(CreateCharacter);
        btnTest.onClick.AddListener(Test);
    }
    private void OnDisable()
    {
        btnNewGame.onClick.RemoveListener(BtnNewGame);
        btnContinue.onClick.RemoveListener(BtnContinue);
        btnCreate.onClick.RemoveListener(CreateCharacter);
        btnTest.onClick.RemoveListener(Test);
    }
    private void Start()
    {
        loadingScreen.SetActive(false);
    }
    private void BtnNewGame()
    {
        //loadingScreen.SetActive(true);
        Home.SetActive(false);
        NewGame.SetActive(true);
        characterInstance = Instantiate(characterPrefab, characterSpot.transform);
        characterSpot.SetActive(true);
    }
    private void BtnContinue()
    {
        loadingScreen.SetActive(true);
    }
    private void CreateCharacter()
    {
        GameManager.Instance.SaveCharacter(characterInstance.GetComponent<CharacterCustomize>());
    }
    private void Test()
    {
        characterCustomize.ChangeHair(true);
    }
}
