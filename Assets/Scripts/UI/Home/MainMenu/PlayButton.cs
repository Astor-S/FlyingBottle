using GameService;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace UI.Home.MainMenu
{
    public class PlayButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private List<string> _levelScenes = new();

        private SavesYG _savesYG;

        private Dictionary<Levels, string> _levelToSceneName = new();

        private void Awake()
        {
            InitializeDictionary();
        }     

        private void Start()
        {
            _savesYG = YandexGame.savesData;
            UpdateLevelToSceneNameFromList();
        }

        public void OnPlayButtonClick()
        {
            string sceneNameToLoad = GetSceneNameForLastOpenedLevel();

            if (string.IsNullOrEmpty(sceneNameToLoad) == false)
                StartCoroutine(LoadLevelAsync(sceneNameToLoad));
        }

        private void InitializeDictionary()
        {
            _levelToSceneName = new Dictionary<Levels, string>()
            {
                { Levels.Level1,  ""},
                { Levels.Level2,  ""},
                { Levels.Level3,  ""},
                { Levels.Level4,  ""},
                { Levels.Level5,  ""},
                { Levels.Level6,  ""},
                { Levels.Level7,  ""},
                { Levels.Level8,  ""},
                { Levels.Level9,  ""},
                { Levels.Level10, ""},
                { Levels.Level11, ""},
                { Levels.Level12, ""},
                { Levels.Level13, ""},
                { Levels.Level14, ""},
                { Levels.Level15, ""},
                { Levels.Level16, ""},
                { Levels.Level17, ""},
                { Levels.Level18, ""},
                { Levels.Level19, ""},
                { Levels.Level20, ""}
            };
        }

        private void UpdateLevelToSceneNameFromList()
        {
            if (_levelScenes == null || _levelScenes.Count == 0)
                return;
            
            var updatedValues = _levelToSceneName.Keys.Zip(_levelScenes, (key, sceneName) => (key, sceneName)).ToList();

            foreach (var (key, sceneName) in updatedValues)
                _levelToSceneName[key] = sceneName; 
        }

        private string GetSceneNameForLastOpenedLevel()
        {
            if (_savesYG.openedLevels == null || _savesYG.openedLevels.Count == 0)
                return null;
            
            Levels lastOpenedLevel = _savesYG.openedLevels[^1];

            return GetSceneNameFromLevel(lastOpenedLevel);
        }

        private string GetSceneNameFromLevel(Levels level)
        {
            if (_levelToSceneName.TryGetValue(level, out string sceneName))
                return sceneName;
            
            return null;
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