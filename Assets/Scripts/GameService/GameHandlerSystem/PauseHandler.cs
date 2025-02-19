using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Screens.LevelScreens.ScreenButtons;

namespace GameService.GameHandlerSystem
{
    public class PauseHandler : MonoBehaviour
    {
        private readonly float _pauseDelayForSeconds = 0.1f;

        [SerializeField] private ReviveButton _reviveButton;
        [SerializeField] private List<LoadSceneButton> _loadSceneButtons;

        private WaitForSeconds _waitPauseDelayForSeconds;

        private void Awake()
        {
            _waitPauseDelayForSeconds = new WaitForSeconds(_pauseDelayForSeconds);
        }

        private void OnEnable()
        {
            _reviveButton.OnGameContinue += ContinueGame;
            
            foreach (var button in _loadSceneButtons)
                button.OnGameContinue += ContinueGame; 
        }

        private void OnDisable()
        {
            _reviveButton.OnGameContinue -= ContinueGame;
            
            foreach (var button in _loadSceneButtons)
                button.OnGameContinue -= ContinueGame;
        }

        public IEnumerator PauseGameDelayed()
        {
            yield return _waitPauseDelayForSeconds;

            PauseGame();
        }

        private void PauseGame() =>
            Time.timeScale = 0f;

        private void ContinueGame() => 
            Time.timeScale = 1f;
    }
}