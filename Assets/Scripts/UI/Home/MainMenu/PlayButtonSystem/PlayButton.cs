using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using GameService;
using YG;

namespace UI.Home.MainMenu.PlayButtonSystem
{
    public class PlayButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private List<string> _levelScenes = new();
        [SerializeField] private LevelSceneHandler _levelSceneHandler;
        [SerializeField] private LevelLoader _levelLoader;

        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
            _levelSceneHandler.UpdateLevelToSceneNameFromList(_levelScenes);
        }

        public void OnPlayButtonClick()
        {
            string sceneNameToLoad = GetSceneNameForLastOpenedLevel();

            if (string.IsNullOrEmpty(sceneNameToLoad) == false)
                StartCoroutine(_levelLoader.LoadLevelAsync(sceneNameToLoad));
        }

        private string GetSceneNameForLastOpenedLevel()
        {
            if (_savesYG.openedLevels == null || _savesYG.openedLevels.Count == 0)
                return null;
            
            Levels lastOpenedLevel = _savesYG.openedLevels[^1];

            return _levelSceneHandler.GetSceneNameFromLevel(lastOpenedLevel);
        }
    }
}