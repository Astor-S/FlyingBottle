using UnityEngine;
using System.Collections;
using UI.Screens.LevelScreens;
using GameService.ComboCounterService;
using PlayerControlSystem;
using YG;

namespace GameService
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerControlSystem.LoaderService.PlayerLoader _playerLoader;
        [SerializeField] private FailScreen _failScreen;
        [SerializeField] private CompleteScreen _completeScreen;
        [SerializeField] private ComboCounter _comboCounter;

        [SerializeField] private int _coinsPerLevel;

        private SavesYG _savesYG;
        private Player _player;
        private WaitForSeconds _waitPauseDelayForSeconds;

        private float _pauseDelayForSeconds = 0.1f;
        private int _totalCoins;

        public int TotalCoins => _totalCoins;

        private void Awake()
        {
            _waitPauseDelayForSeconds = new WaitForSeconds(_pauseDelayForSeconds);
        }

        private void Start()
        {
            _savesYG = YandexGame.savesData;
            StartCoroutine(WaitForPlayer());
        }

        private void OnDisable()
        {
            UnsubscribeFromPlayerEvents();
        }

        private void SubscribeToPlayerEvents()
        {
            if (_player != null)
            {
                _player.GameOver += OnGameOver;
                _player.LevelComplete += OnCompleteLevel;
            }

        }

        private void UnsubscribeFromPlayerEvents()
        {
            if (_player != null)
            {
                _player.GameOver -= OnGameOver;
                _player.LevelComplete -= OnCompleteLevel;
            }
        }

        private IEnumerator WaitForPlayer()
        {
            while (PlayerControlSystem.LoaderService.PlayerLoader.Instance == null)
            {
                yield return null;
            }

            _player = PlayerControlSystem.LoaderService.PlayerLoader.Instance;
            SubscribeToPlayerEvents();
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
            _savesYG.balanceMoney += _totalCoins;
            _savesYG.score += _totalCoins;
            YandexGame.SaveProgress();
        }
    }
}