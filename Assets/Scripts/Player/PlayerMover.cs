using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private Vector3 _rotationOffset = new Vector3(0f, -0.5f, 0f);
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _jumpDuration = 1f;
    [SerializeField] private float _jumpDistanceX = 2f;
    [SerializeField] private float _rotationStartTime = 0.2f;
    [SerializeField] private float _rotationEndTime = 0.8f;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 _rotationAnchor;
    private Coroutine _jumpCoroutine;
    private AudioSource _audioSource;

    private float _currentRotationAngle;

    private bool _isSurfaced;
    private bool _canDoubleJump;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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

    public void Move()
    {
        if(_isSurfaced || _canDoubleJump)
        {
            if (_jumpCoroutine != null)
                StopCoroutine(_jumpCoroutine);
            
            _jumpCoroutine = StartCoroutine(Moving());
            PlayJumpSound();

            if (_isSurfaced == false)
                _canDoubleJump = false;
        }
    }

    private IEnumerator Moving()
    {
        InitializeJump();

        float currentTime = 0f;

        while (currentTime <= _jumpDuration)
        {
            UpdateJumpPosition(currentTime);
            UpdateRotation(currentTime);

            currentTime += Time.deltaTime;

            yield return null;
        }

        FinalizeJump();
    }

    private void InitializeJump()
    {
        _startPosition = transform.position;
        _targetPosition = _startPosition + Vector3.right * _jumpDistanceX;

        _rotationAnchor = transform.position + _rotationOffset;
        _currentRotationAngle = 0;
    }

    private void UpdateJumpPosition(float currentTime)
    {
        float jumpValue = _jumpCurve.Evaluate(currentTime / _jumpDuration) * _jumpHeight;
        float xPosition = Mathf.Lerp(_startPosition.x, _targetPosition.x, currentTime / _jumpDuration);

        transform.position = new Vector3(xPosition, _startPosition.y + jumpValue, _startPosition.z);
    }

    private void UpdateRotation(float currentTime)
    {
        if (currentTime < _jumpDuration * _rotationStartTime || currentTime > _jumpDuration * _rotationEndTime)
            return;

        float normalizedRotationTime = Mathf.InverseLerp(_jumpDuration * _rotationStartTime, _jumpDuration * _rotationEndTime, currentTime);
        float rotationAngle = -360f * normalizedRotationTime;
        float deltaRotation = rotationAngle - _currentRotationAngle;
        _currentRotationAngle = rotationAngle;

        transform.RotateAround(_rotationAnchor, Vector3.forward, deltaRotation);
    }

    private void FinalizeJump()
    {
        _jumpCoroutine = null;
        transform.rotation = Quaternion.identity;
    }

    private void PlayJumpSound()
    {
        _audioSource.PlayOneShot(_jumpSound);
    }
}