using GameService;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Home.MainMenu.PlayButtonSystem
{
    public class LevelSceneHandler : MonoBehaviour
    {
        private Dictionary<Levels, string> _levelToSceneName = new();

        private void Awake()
        {
            InitializeDictionary();
        }

        public void UpdateLevelToSceneNameFromList(List<string> levelScenes)
        {
            if (levelScenes == null || levelScenes.Count == 0)
                return;

            var updatedValues = _levelToSceneName.Keys.Zip(levelScenes, (key, sceneName) =>
                (key, sceneName)).ToList();

            foreach (var (key, sceneName) in updatedValues)
                _levelToSceneName[key] = sceneName;
        }

        public string GetSceneNameFromLevel(Levels level)
        {
            if (_levelToSceneName.TryGetValue(level, out string sceneName))
                return sceneName;

            return null;
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
    }
}