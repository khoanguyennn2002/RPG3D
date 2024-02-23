
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynLevel(sceneIndex));
    }
    IEnumerator LoadAsynLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progress;
            yield return null;
        }
    }    
}
