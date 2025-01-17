using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;

        public void OnButtonClick()
        {
            StartCoroutine(LoadingScene(_sceneToLoad));
            ContinueGame();
        }

        private IEnumerator LoadingScene(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            while (asyncLoad.isDone == false)
            {
                yield return null;
            }
        }

        private void ContinueGame() =>
            Time.timeScale = 1f;
    }
}