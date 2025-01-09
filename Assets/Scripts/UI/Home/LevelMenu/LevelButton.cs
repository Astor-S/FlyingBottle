using UnityEngine;
using UnityEngine.UI;

namespace UI.Home.LevelMenu
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private LevelCell[] _levelCells;
        [SerializeField] private Button _button;
        
        private int _currentLevelIndex;

        private void Awake()
        {
            _button.onClick.AddListener(LoadCurrentLevel);
        }

        public void SetCurrentLevelIndex(int index) =>
            _currentLevelIndex = index;

        public void UpdateLevelButton()
        {
            if (_levelCells == null || _levelCells.Length == 0)
                return;
            
            if (_currentLevelIndex < 0 || _currentLevelIndex >= _levelCells.Length)
                return;   
        }

        private void LoadCurrentLevel()
        {
            if (_levelCells == null || _levelCells.Length == 0)
                return;
            
            if (_currentLevelIndex < 0 || _currentLevelIndex >= _levelCells.Length)
                return;
            
            _levelCells[_currentLevelIndex].LoadScene();
        }
    }
}