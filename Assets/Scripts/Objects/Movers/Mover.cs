using UnityEngine;

namespace Objects.Movers
{
    public class Mover : MonoBehaviour
    {
        private const float MinDistance = 0.01f;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _start;
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed = 1f;

        private Vector3 _currentDestination;
        private Vector3 _moveDirection;
        private bool _movingToTarget = true;

        private void Start()
        {
            _currentDestination = _start.position;
            CalculateMoveDirection();
        }

        private void FixedUpdate()
        {
            MoveObject();
        }

        private void MoveObject()
        {
            Vector3 nextPosition = _rigidbody.position + _moveDirection * _speed * Time.fixedDeltaTime;

            _rigidbody.MovePosition(nextPosition);

            if ((_rigidbody.position - _currentDestination).sqrMagnitude < MinDistance)
                ChangeDestination();
        }

        private void ChangeDestination()
        {
            _movingToTarget = _movingToTarget == false;

            if (_movingToTarget)
                _currentDestination = _target.position;
            else
                _currentDestination = _start.position;

            CalculateMoveDirection();
        }

        private void CalculateMoveDirection() =>
            _moveDirection = (_currentDestination - _rigidbody.position).normalized;
    }
}