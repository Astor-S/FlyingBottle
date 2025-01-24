using GameService;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace UI.Home.MainMenu
{
    public class PlayButton : MonoBehaviour
    {
        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
        }

        public void OnPlayButtonClick()
        {
            string sceneNameToLoad = GetSceneNameForLastOpenedLevel();

            if (string.IsNullOrEmpty(sceneNameToLoad) == false)
                StartCoroutine(LoadLevelAsync(sceneNameToLoad));
        }

        private string GetSceneNameForLastOpenedLevel()
        {
            if (_savesYG.openedLevels.Count == 0)
                return null;

            Levels lastOpenedLevel = _savesYG.openedLevels[_savesYG.openedLevels.Count - 1];

            return GetSceneNameFromLevel(lastOpenedLevel);
        }

        private string GetSceneNameFromLevel(Levels level)
        {
            return level switch
            {
                Levels.Level1 => "Level 1-1",
                Levels.Level2 => "Level 1-2",
                Levels.Level3 => "Level 1-3",
                Levels.Level4 => "Level 1-4",
                Levels.Level5 => "Level 1-5",
                Levels.Level6 => "Level 2-1",
                Levels.Level7 => "Level 2-2",
                Levels.Level8 => "Level 2-3",
                Levels.Level9 => "Level 2-4",
                Levels.Level10 => "Level 2-5",
                Levels.Level11 => "Level 3-1",
                Levels.Level12 => "Level 3-2",
                Levels.Level13 => "Level 3-3",
                Levels.Level14 => "Level 3-4",
                Levels.Level15 => "Level 3-5",
                Levels.Level16 => "Level 4-1",
                Levels.Level17 => "Level 4-2",
                Levels.Level18 => "Level 4-3",
                Levels.Level19 => "Level 4-4",
                Levels.Level20 => "Level 4-5",
                _ => null,
            };
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