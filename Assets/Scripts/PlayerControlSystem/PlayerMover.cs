using System;
using System.Collections;
using UnityEngine;

namespace PlayerControlSystem
{
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerRotator _rotator;
        [SerializeField] private PositionChecker _positionChecker;
        [SerializeField] private PlayerSounder _sounder;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Bottle _bottle;

        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private AnimationCurve _moveCurve;
        
        [SerializeField] private float _jumpDuration = 1f;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _jumpDistanceX = 2f;

        private Rigidbody _rigidbody;
        private Vector3 _bottleStartPosition;
        
        private Coroutine _moveCoroutine;
        private Coroutine _waitingDoubleJumpCoroutine;
        
        private GroundChecker _groundChecker;

        private bool _isSurfaced;
        private bool _canDoubleJump;

        public event Action Moved;

        public float JumpDuration => _jumpDuration;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundChecker = GetComponent<GroundChecker>();

            _bottleStartPosition = _bottle.transform.localPosition;
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
            if (collision.gameObject.TryGetComponent<Objects.Surface>(out _))
            {
                _isSurfaced = true;
                _canDoubleJump = true;
                DeactivateWaitingDoubleJump();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Objects.Surface>(out _))
                _isSurfaced = false;
        }

        private void OnMoving()
        {
            if (_isSurfaced || _canDoubleJump)
            {
                if (_isSurfaced || (_rotator.IsRotating == false && _canDoubleJump))
                    HandleJump();
                else if (_isSurfaced == false && _canDoubleJump && _rotator.IsRotating)
                    ActivateWaitingDoubleJump();
            }
        }

        private void HandleJump()
        {
            ResetJump();
            
            _moveCoroutine = StartCoroutine(Moving());

            Moved?.Invoke();
            _sounder.PlayJumpSound();

            if (_isSurfaced == false)
                _canDoubleJump = false;
        }

        private void ActivateWaitingDoubleJump()
        {
            if (_waitingDoubleJumpCoroutine == null)
                _waitingDoubleJumpCoroutine = StartCoroutine(WaitStartDoubleJump());
        }

        private void DeactivateWaitingDoubleJump()
        {
            if (_waitingDoubleJumpCoroutine != null)
            {
                StopCoroutine(_waitingDoubleJumpCoroutine);
                _waitingDoubleJumpCoroutine = null;
            }
        }

        private IEnumerator WaitStartDoubleJump()
        {
            while (_rotator.IsRotating)
            {
                yield return null;
            }
            
            HandleJump();

            _waitingDoubleJumpCoroutine = null;
        }

        private IEnumerator Moving()
        {
            float startHeight = _rigidbody.position.y;
            float maxHeight = transform.position.y + _jumpHeight;
            float startPositionX = _rigidbody.position.x;
            float maxPositionX = startPositionX + _jumpDistanceX;

            float time = 0f;

            float normalTime;
            
            _rotator.StopRotation();

            while (time < _jumpDuration || _groundChecker.IsGrounded())
            {
                normalTime = Mathf.Clamp01(time / _jumpDuration);

                Vector3 position = _rigidbody.position;

                position.y = CalculateY();
                position.x = CalculateX();

                if (_positionChecker.CheckPosition(position) == false) 
                   break;

                _rotator.UpdateRotation(this, normalTime);

                _rigidbody.MovePosition(position);

                time += Time.deltaTime;
                
                yield return new WaitForFixedUpdate();
            }

            ResetJump();

            float CalculateY()
            {
                return Mathf.Lerp(startHeight, maxHeight, _jumpCurve.Evaluate(normalTime));
            }

            float CalculateX()
            {
                return Mathf.Lerp(startPositionX, maxPositionX, _moveCurve.Evaluate(normalTime));
            }          
        }

        private void ResetJump()
        {
            if (_moveCoroutine != null)
                StopCoroutine(_moveCoroutine);
            
            _moveCoroutine = null;

            _rotator.ResetRotation();
            _bottle.transform.localPosition = _bottleStartPosition;
            
           _rotator.ResetCurrentRotationAngle();
        }
    }
}