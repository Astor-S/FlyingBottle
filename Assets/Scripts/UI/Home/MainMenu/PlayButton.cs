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
                Levels.Level6 => "Level 1-6",
                Levels.Level7 => "Level 1-7",
                Levels.Level8 => "Level 1-8",
                Levels.Level9 => "Level 1-9",
                Levels.Level10 => "Level 1-10",
                Levels.Level11 => "Level 1-11",
                Levels.Level12 => "Level 1-12",
                Levels.Level13 => "Level 1-13",
                Levels.Level14 => "Level 1-14",
                Levels.Level15 => "Level 1-15",
                Levels.Level16 => "Level 1-16",
                Levels.Level17 => "Level 1-17",
                Levels.Level18 => "Level 1-18",
                Levels.Level19 => "Level 1-19",
                Levels.Level20 => "Level 1-20",
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