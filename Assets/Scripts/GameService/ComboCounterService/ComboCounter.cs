using System;
using UnityEngine;
using System.Threading.Tasks;
using PlayerControlSystem;

namespace GameService.ComboCounterService
{
    public class ComboCounter : MonoBehaviour
    {
        [SerializeField] private ComboCounterView _comboCounterView;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private float _comboResetTime = 2f;

        private int _currentComboCount;
        private int _totalComboCount;
        private bool _isResetting = false;

        public int CurrentComboCount => _currentComboCount;
        public int TotalComboCount => _totalComboCount;

        private void OnEnable()
        {
            _inputReader.Moving += OnMove;
        }
        private void OnDisable()
        {
            _inputReader.Moving -= OnMove;
        }

        private void OnMove()
        {
            Debug.Log("OnMove Called");
            _currentComboCount++;
            _totalComboCount++;

            _comboCounterView.ShowCombo();
            UpdateComboText();

            if (_isResetting)
                return;

            ResetComboAfterDelay();
        }

        private async void ResetComboAfterDelay()
        {
            _isResetting = true;
            
            await Task.Delay(TimeSpan.FromSeconds(_comboResetTime));

            _currentComboCount = 0;
            _comboCounterView.HideCombo();
            UpdateComboText();
            _isResetting = false;
        }

        private void UpdateComboText()
        {
            _comboCounterView.SetComboText($"Combo: {_currentComboCount}");
        }
    }
}