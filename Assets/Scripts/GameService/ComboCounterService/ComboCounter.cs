using UnityEngine;
using PlayerControlSystem;
using System.Collections;

namespace GameService.ComboCounterService
{
    public class ComboCounter : MonoBehaviour
    {
        [SerializeField] private ComboCounterView _comboCounterView;
        [SerializeField] private float _comboResetTime = 1.5f;

        private PlayerMover _playerMover;

        private Coroutine _resetCoroutine;
        private WaitForSeconds _waitComborResetForSeconds;

        private int _currentComboCount;
        private int _totalComboCount;

        public int CurrentComboCount => _currentComboCount;
        public int TotalComboCount => _totalComboCount;

        private void Awake()
        {
            _waitComborResetForSeconds = new WaitForSeconds(_comboResetTime);
        }

        private void Start()
        {
            StartCoroutine(WaitForPlayer());
        }

        private void OnDisable()
        {
            if (_playerMover != null)
            {
                _playerMover.Moved -= OnMove;
            }
            StopResetCoroutine();
        }

        private IEnumerator WaitForPlayer()
        {
            while (PlayerControlSystem.LoaderService.PlayerLoader.Instance == null)
            {
                yield return null;
            }

            _playerMover = PlayerControlSystem.LoaderService.PlayerLoader.Instance.GetComponent<PlayerMover>();
            
            if (_playerMover != null)
                _playerMover.Moved += OnMove; 
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
            yield return _waitComborResetForSeconds;

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