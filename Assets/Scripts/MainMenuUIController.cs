
using UnityEngine;
using UnityEngine.UI;


public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    [SerializeField] private Button btnNewGame;
    [SerializeField] private Button btnContinue;

    private void OnEnable()
    {
        btnNewGame.onClick.AddListener(ClickNewGame);
        btnContinue.onClick.AddListener(ClickContinue);
    }
    private void OnDisable()
    {
        btnNewGame.onClick.RemoveListener(ClickNewGame);
        btnContinue.onClick.RemoveListener(ClickContinue);
    }
    private void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void ClickNewGame()
    {
        loadingScreen.SetActive(true);
    }    
    public void ClickContinue()
    {
        loadingScreen.SetActive(true);
    }    
}
