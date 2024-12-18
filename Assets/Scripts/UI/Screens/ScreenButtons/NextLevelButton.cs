using NaughtyAttributes;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    [Scene]
    [SerializeField] private string _sceneToLoad;

    public void OnButtonClick()
    {
        StartCoroutine(LoadNextLevelAsync(_sceneToLoad));
    }

    private IEnumerator LoadNextLevelAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (asyncLoad.isDone == false)
        {
            yield return null;
        }
    }
}