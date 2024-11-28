using UnityEngine;
using DG.Tweening;

public class BottleJumpRotate : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private KeyCode _keyJump = KeyCode.Space;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _jumpDuration = 1f;
    [SerializeField] private float _rotationDuration = 1f;
    [SerializeField] private string _rotateAnimationTrigger = "Rotate";

    private bool _isGrounded;
    private bool _canDoubleJump;

    private void Update()
    {
        if (Input.GetKeyDown(_keyJump))
        {
            JumpAndRotate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Surface>(out _))
        {
            _isGrounded = true;
            _canDoubleJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Surface>(out _))
        {
            _isGrounded = false;
        }
    }

    private void JumpAndRotate()
    {
        if (_isGrounded)
        {
            Vector3 initialPosition = transform.position;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(initialPosition.y + _jumpHeight, _jumpDuration / 2f).SetEase(Ease.OutCubic));
            sequence.Append(transform.DOMoveY(initialPosition.y, _jumpDuration / 2f).SetEase(Ease.InCubic));

           Rotate(sequence);
        }
        //else if (_canDoubleJump) 
        //{
        //    Vector3 initialPosition = transform.position;

        //    Sequence sequence = DOTween.Sequence();
        //    sequence.Append(transform.DOMoveY(initialPosition.y + _jumpHeight, _jumpDuration / 2f).SetEase(Ease.OutCubic));
        //    sequence.Append(transform.DOMoveY(initialPosition.y, _jumpDuration / 2f).SetEase(Ease.InCubic));

        //    Rotate(sequence);

        //    _canDoubleJump = false;
        //}
    }

    private void Rotate(Sequence sequence)
    {
        //sequence.Join(transform.DORotate(new Vector3(0, 0, 360f), _rotationDuration));
        _animator.SetTrigger(_rotateAnimationTrigger);
    }
}