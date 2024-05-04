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
        loadingScreen.SetActive(true);
        float fakeProgress = 0f;
        while (fakeProgress < 1f)
        {
            fakeProgress += Time.deltaTime * 3f; 
            loadingBar.fillAmount = Mathf.Clamp01(fakeProgress); ;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
     
        loadingScreen.SetActive(false);
    }

}
