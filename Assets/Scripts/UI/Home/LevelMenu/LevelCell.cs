using GameService;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Home.LevelMenu
{
    [CreateAssetMenu(fileName = "NewLevelCell", menuName = "Scriptable Objects/LevelCell")]
    public class LevelCell : ScriptableObject
    {
        [field: SerializeField] public Levels LevelsType { get; private set; }

        [Scene]
        [SerializeField] private string _sceneToLoad;
        [SerializeField] private int _cellIndex;

        public string SceneToLoad => _sceneToLoad;
        public int CellIndex => _cellIndex;

        public void LoadScene()
        {
            if (string.IsNullOrEmpty(_sceneToLoad) == false)
                SceneManager.LoadScene(_sceneToLoad);
        }
    }
}