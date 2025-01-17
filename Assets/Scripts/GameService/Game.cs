using UnityEngine;
using UI.Screens.LevelScreens;
using GameService.ComboCounterService;
using System.Collections;

namespace GameService
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerControlSystem.Player _player;
        [SerializeField] private FailScreen _failScreen;
        [SerializeField] private CompleteScreen _completeScreen;
        [SerializeField] private ComboCounter _comboCounter;

        [SerializeField] private int _coinsPerLevel;

        private WaitForSeconds _waitPauseDelayForSeconds;

        private float _pauseDelayForSeconds = 0.1f;
        private int _totalCoins;

        public int TotalCoins => _totalCoins;

        private void Awake()
        {
            _waitPauseDelayForSeconds = new WaitForSeconds(_pauseDelayForSeconds);
        }

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
            
            StartCoroutine(PauseGameDelayed());
        }

        private void OnCompleteLevel()
        {
            AwardCoins();
            _completeScreen.Open();
            StartCoroutine(PauseGameDelayed());
        }

        private void PauseGame() =>
            Time.timeScale = 0f;

        private IEnumerator PauseGameDelayed()
        {
            yield return _waitPauseDelayForSeconds;

            PauseGame();
        }


        private void AwardCoins()
        {
            _totalCoins += _coinsPerLevel + _comboCounter.TotalComboCount;
        }
    }
}