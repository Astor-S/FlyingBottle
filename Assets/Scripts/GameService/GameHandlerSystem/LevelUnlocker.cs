using UnityEngine;
using YG;

namespace GameService.GameHandlerSystem
{
    public class LevelUnlocker : MonoBehaviour
    {
        [SerializeField] private Levels _levelsToOpen;
       
        private SavesYG _savesYG;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
        }

        public void RequestToOpenLevel()
        {
            if (_savesYG.openedLevels.Contains(_levelsToOpen) == false)
                OpenLevel();
        }

        private void OpenLevel()
        {
            _savesYG.openedLevels.Add(_levelsToOpen);
            YandexGame.SaveProgress();
        }
    }
}