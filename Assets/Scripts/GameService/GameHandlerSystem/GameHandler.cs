using UnityEngine;
using System.Collections;
using PlayerControlSystem;
using PlayerControlSystem.LoaderService;
using Zenject;

namespace GameService.GameHandlerSystem
{
    public class GameHandler : MonoBehaviour
    {
        [Inject] private readonly PlayerLoader _playerLoader;
        [SerializeField] private GameEnder _gameEnder;
        [SerializeField] private LevelCompletionHandler _levelCompletionHandler;

        private Player _player;

        private void Start()
        {
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