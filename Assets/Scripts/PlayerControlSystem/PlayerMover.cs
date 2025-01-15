using System.Collections;
using UnityEngine;

namespace PlayerControlSystem
{
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerMover : MonoBehaviour
    {
        private const float FullRotationDegrees = -360f;

        private readonly RaycastHit[] _hits = new RaycastHit[1];

        [SerializeField] private Bottle _bottle;
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private LayerMask _groundMask;

        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private AnimationCurve _moveCurve;
        [SerializeField] private AnimationCurve _rotationCurve;

        [SerializeField] private AudioClip _jumpSound;
        
        [SerializeField] private float _jumpDuration = 1f;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _jumpDistanceX = 2f;
        [SerializeField][Range(0, 1)] private float _rotationStartTime = 0.2f;
        [SerializeField][Range(0, 1)] private float _rotationEndTime = 0.8f;
        [SerializeField] private Transform _rotationAnchor;

        private Rigidbody _rigidbody;
        private Vector3 _bottleStartPosition;
        
        private Coroutine _moveCoroutine;
        private Coroutine _waitingDoubleJumpCoroutine;
        
        private AudioSource _audioSource;
        private GroundChecker _groundChecker;

        private float _currentRotationAngle;
        private float _currentJumpTime; 
        
        private bool _isRotating;
        private bool _isSurfaced;
        private bool _canDoubleJump;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();
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
                if (_isSurfaced || (_isRotating == false && _canDoubleJump))
                    StartJump();
                else if (_isSurfaced == false && _canDoubleJump && _isRotating)
                    ActivateWaitingDoubleJump();
            }
        }

        private void StartJump()
        {
            ResetJump();
            
            _moveCoroutine = StartCoroutine(Moving());
            
            PlayJumpSound();
            
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
            while (_isRotating)
            {
                yield return null;
            }
            
            StartJump();

            _waitingDoubleJumpCoroutine = null;
        }

        private IEnumerator Moving()
        {
            float startHeight = _rigidbody.position.y;
            float maxHeight = transform.position.y + _jumpHeight;
            float startPositionX = _rigidbody.position.x;
            float maxPositionX = startPositionX + _jumpDistanceX;

            float time = 0f;
            _currentJumpTime = 0f;
           
            float normalTime;
            _isRotating = false;

            while (time < _jumpDuration || _groundChecker.IsGrounded())
            {
                normalTime = Mathf.Clamp01(time / _jumpDuration);

                Vector3 position = _rigidbody.position;

                position.y = CalculateY();
                position.x = CalculateX();

                if (CheckPosition(position) == false) 
                   break;

                UpdateRotation(normalTime);

                _rigidbody.MovePosition(position);

                time += Time.deltaTime;
                _currentJumpTime = time;

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

            bool CheckPosition(Vector3 position)
            {
                Vector3 direction = (position - _rigidbody.position).normalized;
                float distance = (_rigidbody.position - position).sqrMagnitude;

                int count = Physics.BoxCastNonAlloc(
                    _boxCollider.bounds.center,
                    _boxCollider.bounds.extents * 0.5f,
                    direction,
                    _hits,
                    _bottle.transform.rotation,
                    distance,
                    _groundMask);

                return count == 0;
            }
        }

        private void UpdateRotation(float currentTime)
        {
            if (currentTime > _jumpDuration * _rotationStartTime && currentTime < _jumpDuration * _rotationEndTime)
                _isRotating = true;
            else if (currentTime >= _jumpDuration * _rotationEndTime)
                _isRotating = false; 
            
            if (currentTime < _jumpDuration * _rotationStartTime || currentTime > _jumpDuration * _rotationEndTime)
                return;

            float normalizedRotationTime = Mathf.InverseLerp(_jumpDuration * _rotationStartTime, _jumpDuration * _rotationEndTime, currentTime);
            float rotationCurveValue = _rotationCurve.Evaluate(normalizedRotationTime);
            float rotationAngle = FullRotationDegrees * rotationCurveValue;
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
            
            _currentRotationAngle = 0f;
        }

        private void PlayJumpSound() =>
            _audioSource.PlayOneShot(_jumpSound);
    }
}