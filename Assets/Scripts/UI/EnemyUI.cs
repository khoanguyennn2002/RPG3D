
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider easeSlider;
    [SerializeField] private Enemy enemy;

    private float lerpSpeed = 0.05f;

    private void OnEnable()
    {
        enemy.UpdateHealth += SetHpUI;
    }
    private void OnDestroy()
    {
        
    }
    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        hpSlider.maxValue = enemy.Health;
        easeSlider.maxValue = enemy.Health;

        hpSlider.value = enemy.Health;
        easeSlider.value = enemy.Health;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public void SetHpUI()
    {
        hpSlider.value = enemy.Health;
    }

    private void Update()
    {
        if(hpSlider.value != easeSlider.value)
        {
            easeSlider.value = Mathf.Lerp(easeSlider.value, enemy.Health, lerpSpeed);
            Debug.Log("a");
        }
    }
}
