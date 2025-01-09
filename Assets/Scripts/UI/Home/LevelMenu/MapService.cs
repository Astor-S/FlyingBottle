using UnityEngine;

namespace UI.Home.LevelMenu
{
    public class MapService : MonoBehaviour
    {
        private const int FirstLocation = 0;
        private const int CorrectionShift = 1;

        [SerializeField] private Map[] _levelDataByLocation;
        [SerializeField] private LevelButton[] _levelButtons;
        [SerializeField] private MapDisplay _mapDisplay;

        private int _currentLocationIndex;

        private void Awake()
        {
            ChangeLocation(FirstLocation);
        }

        public void ChangeLocation(int change)
        {
            _currentLocationIndex += change;

            if (_currentLocationIndex < FirstLocation)
                _currentLocationIndex = _levelDataByLocation.Length - CorrectionShift;
            else if (_currentLocationIndex > _levelDataByLocation.Length - CorrectionShift)
                _currentLocationIndex = FirstLocation;

            if(_mapDisplay != null)
                _mapDisplay.DisplayMap(_levelDataByLocation[_currentLocationIndex]);

            UpdateLevelButtons();
        }

        private void UpdateLevelButtons()
        {
            for (int i = 0; i < _levelButtons.Length; i++)
            {
                int buttonIndex = i;
                _levelButtons[buttonIndex].SetCurrentLevelIndex(_currentLocationIndex);
                _levelButtons[buttonIndex].UpdateLevelButton();
            }
        }
    }
}