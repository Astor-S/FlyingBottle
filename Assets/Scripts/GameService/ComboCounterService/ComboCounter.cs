using UnityEngine;
using PlayerControlSystem;
using System.Collections;

namespace GameService.ComboCounterService
{
    public class ComboCounter : MonoBehaviour
    {
        [SerializeField] private ComboCounterView _comboCounterView;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private float _comboResetTime = 1.5f;

        private Coroutine _resetCoroutine;
        private WaitForSeconds _waitForSeconds;

        private int _currentComboCount;
        private int _totalComboCount;

        public int CurrentComboCount => _currentComboCount;
        public int TotalComboCount => _totalComboCount;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_comboResetTime);
        }

        private void OnEnable()
        {
            _inputReader.Moving += OnMove;
        }

        private void OnDisable()
        {
            _inputReader.Moving -= OnMove;
            StopResetCoroutine();
        }

        private void OnMove()
        {
            _currentComboCount++;
            _totalComboCount++;

            _comboCounterView.ShowCombo();
            UpdateComboText();

            StopResetCoroutine(); 
            _resetCoroutine = StartCoroutine(ResetComboAfterDelay());
        }

        private IEnumerator ResetComboAfterDelay()
        {
            yield return _waitForSeconds;

            _currentComboCount = 0;
            _comboCounterView.HideCombo();
            UpdateComboText();
            
            _resetCoroutine = null; 
        }

        private void StopResetCoroutine()
        {
            if (_resetCoroutine != null)
            {
                StopCoroutine(_resetCoroutine);
                _resetCoroutine = null;
            }
        }

        private void UpdateComboText()
        {
            _comboCounterView.SetComboText($" {_currentComboCount}");
        }
    }
}