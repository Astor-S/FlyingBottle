using UnityEngine;
using System;
using NaughtyAttributes;
using GameService;

namespace UI.Screens.LevelScreens.ScreenButtons
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;
        [SerializeField] private LevelLoader _levelLoader;

        public event Action GameContinued;

        public void OnButtonClick()
        {
            StartCoroutine(_levelLoader.LoadLevelAsync(_sceneToLoad));
            GameContinued?.Invoke();
        }
    }
}