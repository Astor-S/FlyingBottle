using UnityEngine;

namespace Objects
{
    public class ToyCar : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _target;
        [SerializeField] private AudioClip _toyCarSound;
        [SerializeField] private float _duration;

        private AudioSource _audioSource;
        private Vector3 _startPosition;
        private bool _isMoving = false;
        private float _startTime;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (_isMoving == false)
                return;

            float elapsedTime = Time.time - _startTime;

            if (elapsedTime >= _duration)
            {
                _rigidbody.MovePosition(_target.position);
                _isMoving = false;

                return;
            }

            float time = elapsedTime / _duration;

            Vector3 newPosition = Vector3.Lerp(_startPosition, _target.position, time);

            _rigidbody.MovePosition(newPosition);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerControlSystem.Player>(out _))
            {
                StartMovement();

                _audioSource.PlayOneShot(_toyCarSound);
            }
        }

        private void StartMovement()
        {
            _startPosition = transform.position;
            _startTime = Time.time;
            _isMoving = true;
        }
    }
}