using System.Collections;
using UnityEngine;

public class JumpAnimCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _jumpDuration = 1f;
    [SerializeField] private float _endJump = 1f;
    [SerializeField] private float _jumpDistanceX = 2f; 

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Coroutine _jumpCoroutine;

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
        _targetPosition = _startPosition + Vector3.right * _jumpDistanceX;

        float jumpStartTime = Time.time;

        while (enabled)
        {
            float timeSinceJumpStart = Time.time - jumpStartTime;
            float normalizedTime = Mathf.Clamp01(timeSinceJumpStart / _jumpDuration);
            float jumpValue = _jumpCurve.Evaluate(normalizedTime) * _jumpHeight;

            float xPosition = Mathf.Lerp(_startPosition.x, _targetPosition.x, normalizedTime);

            transform.position = new Vector3(xPosition, _startPosition.y + jumpValue, _startPosition.z);

            if (normalizedTime >= _endJump)
            {
                _jumpCoroutine = null;

                yield break;
            }

            yield return null;
        }

        _jumpCoroutine = null;
    }
}