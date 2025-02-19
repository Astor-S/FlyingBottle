using UnityEngine;
using System;
using NaughtyAttributes;
using System.Collections;
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
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
    }
}