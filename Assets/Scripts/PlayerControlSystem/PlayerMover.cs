using System.Collections;
using UnityEngine;

namespace PlayerControlSystem
{
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Bottle _bottle;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private VerticalMoveHandler _verticalMoveHandler;
        [SerializeField] private Vector3 _rotationOffset = new Vector3(0f, -0.5f, 0f);
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private float _jumpDuration = 1f;
        [SerializeField] private float _jumpDistanceX = 2f;
        [SerializeField][Range(0, 1)] private float _rotationStartTime = 0.2f;
        [SerializeField][Range(0, 1)] private float _rotationEndTime = 0.8f;
        [SerializeField] private Transform _rotationAnchor;

        private Vector3 _startPosition;
        private Vector3 _bottleStartPosition;
        private Coroutine _moveCoroutine;
        private AudioSource _audioSource;
        private GroundChecker _groundChecker;

        private float _currentRotationAngle;

        private bool _isSurfaced;
        private bool _canDoubleJump;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _verticalMoveHandler.Init(transform);
            _groundChecker = GetComponent<GroundChecker>();
            _bottleStartPosition = _bottle.transform.localPosition;

            StartCoroutine(Fall());
        }

        private void OnEnable()
        {
            _inputReader.Moving += OnMoving;
        }

        private void OnDisable()
        {
            _inputReader.Moving -= OnMoving;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Surface>(out _))
            {
                _isSurfaced = true;
                _canDoubleJump = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Surface>(out _))
                _isSurfaced = false;
        }

        private void OnMoving()
        {
            if (_isSurfaced || _canDoubleJump)
            {
                ResetJump();

                _moveCoroutine = StartCoroutine(Moving());
                PlayJumpSound();

                if (_isSurfaced == false)
                    _canDoubleJump = false;
            }
        }

        private IEnumerator Moving()
        {
            _currentRotationAngle = 0;
            _startPosition = transform.position;

            var targetPosition = transform.position.x + _jumpDistanceX;

            float currentTime = 0f;

            var maxHeight = transform.position.y + _jumpDistanceX;

            _verticalMoveHandler.Reset();

            var groundPositionY = 0f;

            while (Condition())
            {
                transform.position = new Vector3(
                    CalculateX(),
                    transform.position.y + _verticalMoveHandler.CalculateHeight(maxHeight, currentTime / _jumpDuration, groundPositionY),
                    _startPosition.z);

                UpdateRotation(currentTime);

                currentTime += Time.deltaTime;

                yield return null;
            }

            ResetJump();

            yield break;

            float CalculateX()
            {
                return Mathf.Lerp(_startPosition.x, targetPosition, currentTime / _jumpDuration);
            }

            bool Condition()
            {
                if (_verticalMoveHandler.IsFall)
                {
                    return _groundChecker.IsGrounded(out groundPositionY) == false;
                }
                else
                {
                    return true;
                }
            }
        }

        private IEnumerator Fall()
        {
            _startPosition = transform.position;

            float currentTime = 0f;

            var maxHeight = transform.position.y;

            var duration = _jumpDuration / 2;

            _verticalMoveHandler.Reset();

            while (_groundChecker.IsGrounded(out var groundPositionY) == false)
            {
                transform.position = new Vector3(
                    _startPosition.x,
                    transform.position.y + _verticalMoveHandler.CalculateHeight(maxHeight, currentTime / duration, groundPositionY),
                    _startPosition.z);

                currentTime += Time.deltaTime;

                yield return null;
            }

            Debug.Log("Fall end");

            _moveCoroutine = null;
        }

        private void UpdateRotation(float currentTime)
        {
            if (currentTime < _jumpDuration * _rotationStartTime || currentTime > _jumpDuration * _rotationEndTime)
                return;

            float normalizedRotationTime = Mathf.InverseLerp(_jumpDuration * _rotationStartTime, _jumpDuration * _rotationEndTime, currentTime);
            float rotationAngle = -360f * normalizedRotationTime;
            float deltaRotation = rotationAngle - _currentRotationAngle;
            _currentRotationAngle = rotationAngle;

            _bottle.transform.RotateAround(_rotationAnchor.position, Vector3.forward, deltaRotation);
        }

        private void ResetJump()
        {
            if (_moveCoroutine != null)
                StopCoroutine(_moveCoroutine);
            
            _moveCoroutine = null;
            _bottle.transform.rotation = Quaternion.identity;
            _bottle.transform.localPosition = _bottleStartPosition;
        }

        private void PlayJumpSound()
        {
            _audioSource.PlayOneShot(_jumpSound);
        }
    }
}