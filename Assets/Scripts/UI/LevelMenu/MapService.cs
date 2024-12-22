using UnityEngine;

namespace UI.LevelMenu
{
    public class MapService : MonoBehaviour
    {
        private const int FirstLocation = 0;
        private const int CorrectionShift = 1;

        [SerializeField] private ScriptableObject[] _scriptableObjects;
        [SerializeField] private MapDisplay _mapDisplay;

        private int _currentIndex;

        private void Awake()
        {
            ChangerScriptableObject(FirstLocation);
        }

        public void ChangerScriptableObject(int change)
        {
            _currentIndex += change;

            if (_currentIndex < FirstLocation)
                _currentIndex = _scriptableObjects.Length - CorrectionShift;
            else if (_currentIndex > _scriptableObjects.Length - CorrectionShift)
                _currentIndex = FirstLocation;

            if(_mapDisplay != null)
                _mapDisplay.DisplayMap((Map)_scriptableObjects[_currentIndex]);
        }
    }
}