using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class PlayButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;

        public void OnPlayButtonClick()
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
}