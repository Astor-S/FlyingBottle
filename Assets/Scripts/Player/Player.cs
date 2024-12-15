using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    //[SerializeField] private PlayerMover _playerMover;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private JumpAnimCurve _jumpAnimCurve;

    public event Action GameOver;
    public event Action LevelComplete;

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        _inputReader.Moved += OnMove;
        _collisionDetector.FailedCollide += GameOver;
        _collisionDetector.FinishedCollide += LevelComplete;
    }

    private void RemoveListeners()
    {
        _inputReader.Moved -= OnMove;
        _collisionDetector.FailedCollide -= GameOver;
        _collisionDetector.FinishedCollide -= LevelComplete;
    }

    private void OnMove()
    {
        //_playerMover.Move();
        _jumpAnimCurve.Move();
    }
}