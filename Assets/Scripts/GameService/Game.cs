using UnityEngine;
using UI.Screens.LevelScreens;

namespace GameService
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerControlSystem.Player _player;
        [SerializeField] private FailScreen _failScreen;
        [SerializeField] private CompleteScreen _completeScreen;

        private void OnEnable()
        {
            _player.GameOver += OnGameOver;
            _player.LevelComplete += OnCompleteLevel;
        }

        private void OnDisable()
        {
            _player.GameOver -= OnGameOver;
            _player.LevelComplete -= OnCompleteLevel;
        }

        private void OnGameOver()
        {
            _failScreen.Open();
            PauseGame();
        }

        private void OnCompleteLevel()
        {
            _completeScreen.Open();
            PauseGame();
        }

        private void PauseGame() =>
            Time.timeScale = 0f;
    }
}