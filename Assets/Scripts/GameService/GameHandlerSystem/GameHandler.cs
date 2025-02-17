using UnityEngine;
using System.Collections;
using PlayerControlSystem;
using PlayerControlSystem.LoaderService;
using Zenject;

namespace GameService.GameHandlerSystem
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private GameEnder _gameEnder;
        [SerializeField] private LevelCompletionHandler _levelCompletionHandler;
        private  PlayerLoader _playerLoader;

        private Player _player;

        private void Awake()
        {
            Init(_playerLoader);
        }

        private void Start()
        {
            StartCoroutine(WaitForPlayer());
        }

        private void OnDisable()
        {
            UnsubscribeFromPlayerEvents();
        }

        [Inject]
        private void Init(PlayerLoader playerLoader) =>
            _playerLoader = playerLoader;

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

        private void OnGameOver() =>
            _gameEnder.HandleGameOver();

        private void OnCompleteLevel() =>
            _levelCompletionHandler.HandleLevelCompletion();
    }
}