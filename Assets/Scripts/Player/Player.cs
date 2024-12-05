using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CollisionDetector _collisionDetector;

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
        _collisionDetector.FailedCollide += GameOver;
        _collisionDetector.FinishedCollide += LevelComplete;
    }

    private void RemoveListeners()
    {
        _collisionDetector.FailedCollide -= GameOver;
        _collisionDetector.FinishedCollide -= LevelComplete;
    }
}