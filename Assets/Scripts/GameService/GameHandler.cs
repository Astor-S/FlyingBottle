using UnityEngine;
using System.Collections;
using UI.Screens;
using UI.Screens.ScreenButtons;
using GameService.ComboCounterService;
using PlayerControlSystem;
using PlayerControlSystem.LoaderService;
using Zenject;
using YG;

namespace GameService
{
    public class GameHandler : MonoBehaviour
    {
        [Inject] private readonly PlayerLoader _playerLoader;
        [SerializeField] private PauseHandler _pauseHandler;
        [SerializeField] private FailScreen _failScreen;
        [SerializeField] private CompleteScreen _completeScreen;
        [SerializeField] private ComboCounter _comboCounter;
        [SerializeField] private CoinDoublingButton _coinDoubling;
        [SerializeField] private Levels _levelsToOpen;
        [SerializeField] private int _coinsPerLevel;

        private SavesYG _savesYG;
        private Player _player;

        private int _totalCoins;
        private int _levelCoins;

        public int TotalCoins => _totalCoins;

        private void Start()
        {
            _savesYG = YandexGame.savesData;
            StartCoroutine(WaitForPlayer());
        }

        private void OnEnable()
        {
            _coinDoubling.OnDoubleAwards += HandleDoubleAwardRequest;
        }

        private void OnDisable()
        {
            UnsubscribeFromPlayerEvents();
            _coinDoubling.OnDoubleAwards -= HandleDoubleAwardRequest;
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
            while (_playerLoader == null)
            {
                yield return null;
            }

            _player = _playerLoader.GetPlayer();
            SubscribeToPlayerEvents();
        }

        private void OnGameOver()
        {
            _failScreen.Open();
            
            StartCoroutine(_pauseHandler.PauseGameDelayed());
        }

        private void OnCompleteLevel()
        {
            AwardCoins();
            RequestToOpenLevel();
            _completeScreen.Open();
            StartCoroutine(_pauseHandler.PauseGameDelayed());
        }

        private void AwardCoins()
        {
            _levelCoins = _coinsPerLevel + _comboCounter.TotalComboCount;
            _totalCoins += _levelCoins;
            SaveProgress();
        }

        private void HandleDoubleAwardRequest()
        {
            _totalCoins += _levelCoins;
            SaveProgress();
        }

        private void RequestToOpenLevel()
        {
            if (_savesYG.openedLevels.Contains(_levelsToOpen) == false)
                OpenLevel();
        }

        private void OpenLevel()
        {
            _savesYG.openedLevels.Add(_levelsToOpen);
            YandexGame.SaveProgress();
        }

        private void SaveProgress()
        {
            _savesYG.balanceMoney += _levelCoins;
            _savesYG.score += _levelCoins;
            YandexGame.SaveProgress();
            AddNewLeaderboardScores();
        }

        private void AddNewLeaderboardScores()
        {
            int score = _savesYG.score;
            YandexGame.NewLeaderboardScores("BestPlayers", score);
        }
    }
}