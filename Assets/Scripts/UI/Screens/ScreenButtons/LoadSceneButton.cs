using NaughtyAttributes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;

        public event Action OnGameContinue;

        public void OnButtonClick()
        {
            StartCoroutine(LoadingScene(_sceneToLoad));
            OnGameContinue?.Invoke();
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
}