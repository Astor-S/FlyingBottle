using UI.Screens.LevelScreens.ScreenButtons;
using UnityEngine;

namespace GameService
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private ReviveButton _reviveButton;

        private void OnEnable()
        {
            _reviveButton.OnGameContinue += ContinueGame;
        }

        private void OnDisable()
        {
            _reviveButton.OnGameContinue -= ContinueGame;
        }

        private void PauseGame() =>
            Time.timeScale = 0f;

        private void ContinueGame() => 
            Time.timeScale = 1f;
    }
}