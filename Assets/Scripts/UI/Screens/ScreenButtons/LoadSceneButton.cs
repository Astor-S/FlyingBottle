using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    [Scene]
    [SerializeField] private string _sceneToLoad;

    public void OnButtonClick()
    {
        StartCoroutine(LoadingScene(_sceneToLoad));
    }

    private IEnumerator LoadingScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (asyncLoad.isDone == false)
        {
            yield return null;
        }
    }
}