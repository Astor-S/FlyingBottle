using UnityEngine;
using DG.Tweening;

//public class PlayerMover : MonoBehaviour
//{
//    private const float HalfJumpDuration = 2f;

//    [SerializeField] private Animator _animator;
//    [SerializeField] private AudioClip _jumpSound;
//    [SerializeField] private float _jumpHeight = 2f;
//    [SerializeField] private float _jumpDistance = 2f;
//    [SerializeField] private float _jumpDuration = 1f;
//    [SerializeField] private float _rotationDuration = 1f;
//    [SerializeField] private float _doubleJumpHeightFactor = 0.7f;
//    [SerializeField] private float _targetRotation = 90f;
//    [SerializeField] private string _rotateAnimationTrigger = "Rotate";

//    private Quaternion _initialRotation;
//    private AudioSource _audioSource;

//    private bool _isGrounded;
//    private bool _canDoubleJump;

//    private void Awake()
//    {
//        _audioSource = GetComponent<AudioSource>();
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.TryGetComponent<Surface>(out _))
//        {
//            _isGrounded = true;
//            _canDoubleJump = true;
//            _initialRotation = transform.rotation;
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        if (collision.gameObject.TryGetComponent<Surface>(out _))
//        {
//            _isGrounded = false;
//        }
//    }

//    public void Move()
//    {
//        if (_isGrounded)
//        {
//            Vector3 initialPosition = transform.position;
//            Vector3 targetPosition = initialPosition + new Vector3(_jumpDistance, _jumpHeight, 0);

//            Sequence sequence = DOTween.Sequence();
//            sequence.Append(transform.DOMove(targetPosition, _jumpDuration / HalfJumpDuration).SetEase(Ease.OutCubic));
//            sequence.Append(transform.DOMove(new Vector3(initialPosition.x + _jumpDistance, initialPosition.y, initialPosition.z), _jumpDuration / HalfJumpDuration).SetEase(Ease.InCubic));

//            PlayJumpSound();
//            Rotate(sequence);
//        }
//        else if (_canDoubleJump)
//        {
//            Vector3 initialPosition = transform.position;
//            float doubleJumpHeight = _jumpHeight * _doubleJumpHeightFactor;
//            Vector3 targetPosition = initialPosition + new Vector3(_jumpDistance, doubleJumpHeight, 0);
 
//            Sequence sequence = DOTween.Sequence();
//            sequence.Append(transform.DOMove(targetPosition, _jumpDuration / HalfJumpDuration).SetEase(Ease.OutCubic));
//            sequence.Append(transform.DOMove(new Vector3(initialPosition.x + _jumpDistance, initialPosition.y, initialPosition.z), _jumpDuration / HalfJumpDuration).SetEase(Ease.InCubic));

//            PlayJumpSound();
//            Rotate(sequence);

//            _canDoubleJump = false;
//        }
//    }

//    private void Rotate(Sequence sequence)
//    {
//        Quaternion targetRotation = _initialRotation * Quaternion.Euler(0, _targetRotation, 0);

//        sequence.Append(transform.DORotateQuaternion(targetRotation, _rotationDuration).SetEase(Ease.Linear)); 
//        _animator.SetTrigger(_rotateAnimationTrigger);
//    }

//    private void PlayJumpSound()
//    {
//        _audioSource.PlayOneShot(_jumpSound);
//    }
//}