using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
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
    }

    private void OnCompleteLevel()
    {
        _completeScreen.Open();
    }
}