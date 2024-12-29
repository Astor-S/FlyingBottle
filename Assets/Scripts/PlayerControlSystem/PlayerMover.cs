using System.Collections;
using UnityEngine;

namespace PlayerControlSystem
{
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerMover : MonoBehaviour
    {
        private readonly RaycastHit[] _hits = new RaycastHit[1];

        [SerializeField] private Bottle _bottle;
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private AnimationCurve _moveCurve;
        [SerializeField] private Vector3 _rotationOffset = new Vector3(0f, -0.5f, 0f);
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private float _jumpDuration = 1f;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _jumpDistanceX = 2f;
        [SerializeField][Range(0, 1)] private float _rotationStartTime = 0.2f;
        [SerializeField][Range(0, 1)] private float _rotationEndTime = 0.8f;
        [SerializeField] private Transform _rotationAnchor;

        private Rigidbody _rigidbody;
        private Vector3 _startPosition;
        private Vector3 _bottleStartPosition;
        private Coroutine _moveCoroutine;
        private AudioSource _audioSource;
        private GroundChecker _groundChecker;

        private float _currentRotationAngle;

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
            var startHeight = _rigidbody.position.y;
            var maxHeight = transform.position.y + _jumpHeight;
            var startPositionX = _rigidbody.position.x;
            var maxPositionX = startPositionX + _jumpDistanceX;

            var time = 0f;
            
            float normalTime;

            while (time < _jumpDuration || _groundChecker.IsGrounded())
            {
                normalTime = Mathf.Clamp01(time / _jumpDuration);

                var position = _rigidbody.position;

                position.y = CalculateY();
                position.x = CalculateX();

                if (CheckPosition(position) == false) 
                   break;
                print(2);
                //UpdateRotation(currentTime);

                _rigidbody.MovePosition(position);

                time += Time.deltaTime;

                yield return new WaitForFixedUpdate();
            }

            Debug.Log("End");

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
                var direction = (position - _rigidbody.position).normalized;
                var distance =  Vector3.Distance(_rigidbody.position, position);

                var count = Physics.BoxCastNonAlloc(
                    _boxCollider.bounds.center,
                    _boxCollider.bounds.extents * 0.5f,
                    direction,
                    _hits,
                    _bottle.transform.rotation,
                    distance,
                    _groundMask);

                Debug.Log($"{count}");

                return count == 0;
            }
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