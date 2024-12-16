using System.Collections;
using UnityEngine;
using DG.Tweening;

public class JumpAnimCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private AnimationCurve _rotationCurve = AnimationCurve.Linear(0, 0, 1, 360);
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _jumpDuration = 1f;
    [SerializeField] private float _endJump = 1f;
    [SerializeField] private float _jumpDistanceX = 2f; 

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Coroutine _jumpCoroutine;
    private Tween _rotationTween;

    private bool _isSurfaced;
    private bool _canDoubleJump;

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
        if (_isSurfaced == false)
            return;

        if (_jumpCoroutine != null)
            StopCoroutine(_jumpCoroutine);

        _jumpCoroutine = StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {
        _startPosition = transform.position;
        var startRotation = Vector3.zero;
        _targetPosition = _startPosition + Vector3.right * _jumpDistanceX;

        float jumpStartTime = Time.time;

        _rotationTween = transform.DORotate(
            new Vector3(0, 0, -360f),
            _jumpDuration,
            RotateMode.FastBeyond360).SetEase(Ease.Linear);

        float currentTime = 0f;

        while (currentTime <= _jumpDuration)
        {
            float jumpValue = _jumpCurve.Evaluate(currentTime / _jumpDuration) * _jumpHeight;
            float xPosition = Mathf.Lerp(_startPosition.x, _targetPosition.x, currentTime);

            transform.position = new Vector3(xPosition, _startPosition.y + jumpValue, _startPosition.z);

            currentTime += Time.deltaTime;

            yield return null;
        }

        _jumpCoroutine = null;
        _rotationTween?.Kill();
        transform.rotation = Quaternion.identity;
    }
}