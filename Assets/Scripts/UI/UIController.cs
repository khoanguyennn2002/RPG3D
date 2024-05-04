using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider mpBar;
    [SerializeField] private Slider expBar;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI mpText;
    [SerializeField] private TextMeshProUGUI expText;
    private void Awake()
    {
        GameManager.Instance.playerProfile.SetUIController(this);
    }
    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        hpBar.maxValue = maxHealth;
        hpBar.value = currentHealth;
        hpText.text = $"{currentHealth} / {maxHealth}";
    }

    public void UpdateManaUI(int currentMana, int maxMana)
    {
        mpBar.maxValue = maxMana;
        mpBar.value = currentMana;
        mpText.text = $"{currentMana} / {maxMana}";
    }

    public void UpdateExperienceUI(int currentXP, int maxXP, int level)
    {
        expBar.maxValue = maxXP;
        expBar.value = currentXP;
        expText.text = level.ToString();
    }

    public void SetExpUI(int exp)
    {
        expBar.value = exp;
    }    
    public void SetHealthUI(int hp)
    {
        hpBar.value = hp;
    }    
    public void SetManaUI(int mp)
    {
        mpBar.value = mp;
    }    
}
