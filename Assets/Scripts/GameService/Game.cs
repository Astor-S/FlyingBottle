using UnityEngine;
using UI.Screens.LevelScreens;
using GameService.ComboCounterService;

namespace GameService
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerControlSystem.Player _player;
        [SerializeField] private FailScreen _failScreen;
        [SerializeField] private CompleteScreen _completeScreen;
        [SerializeField] private ComboCounter _comboCounter;

        [SerializeField] private int _coinsPerLevel;

        private int _totalCoins;

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
            AwardCoins();
            _completeScreen.Open();
            PauseGame();
        }

        private void PauseGame() =>
            Time.timeScale = 0f;

        private void AwardCoins()
        {
            _totalCoins += _coinsPerLevel + _comboCounter.TotalComboCount;
            Debug.Log($"Level Complete! Awarded: {_coinsPerLevel} + {_comboCounter.TotalComboCount} coins. Total coins: {_totalCoins}");
        }
    }
}