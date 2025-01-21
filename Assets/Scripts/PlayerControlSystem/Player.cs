using System;
using UnityEngine;

namespace PlayerControlSystem
{
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
            _collisionDetector.FailedCollide += OnFailedCollide;
            _collisionDetector.FinishedCollide += OnFinishedCollide;
        }

        private void RemoveListeners()
        {
            _collisionDetector.FailedCollide -= OnFailedCollide;
            _collisionDetector.FinishedCollide -= OnFinishedCollide;
        }
        private void OnFailedCollide() =>
            GameOver?.Invoke();

        private void OnFinishedCollide() =>
            LevelComplete?.Invoke();
    }
}