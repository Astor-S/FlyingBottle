using System.Collections;
using UI.Screens.LevelScreens.ScreenButtons;
using UnityEngine;

namespace GameService.GameHandlerSystem
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private ReviveButton _reviveButton;

        private WaitForSeconds _waitPauseDelayForSeconds;

        private readonly float _pauseDelayForSeconds = 0.1f;

        private void Awake()
        {
            _waitPauseDelayForSeconds = new WaitForSeconds(_pauseDelayForSeconds);
        }

        private void OnEnable()
        {
            _reviveButton.OnGameContinue += ContinueGame;
        }

        private void OnDisable()
        {
            _reviveButton.OnGameContinue -= ContinueGame;
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