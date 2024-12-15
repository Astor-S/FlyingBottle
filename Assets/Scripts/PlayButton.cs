using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [Scene]
    [SerializeField] private string _sceneToLoad;

    private void OnButtonClick()
    {
        StartCoroutine(LoadLevelAsync(_sceneToLoad));
    }

    private IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (asyncLoad.isDone == false)
        {
            yield return null;
        }
    }
}