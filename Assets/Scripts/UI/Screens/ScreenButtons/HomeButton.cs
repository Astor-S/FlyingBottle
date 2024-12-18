using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    [Scene]
    [SerializeField] private string _sceneToLoad;

    private void OnButtonClick()
    {
        StartCoroutine(LoadHomeAsync(_sceneToLoad));
    }

    private IEnumerator LoadHomeAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (asyncLoad.isDone == false)
        {
            yield return null;
        }
    }
}