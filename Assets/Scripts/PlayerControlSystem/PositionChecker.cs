using UnityEngine;

namespace PlayerControlSystem
{
    public class PositionChecker : MonoBehaviour
    {
        private readonly RaycastHit[] _hits = new RaycastHit[1];

        [SerializeField] private Bottle _bottle;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private BoxCollider _boxCollider;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _boxCastExtentsMultiplier = 0.5f;

        public bool CheckPosition(Vector3 position)
        {
            Vector3 direction = (position - _rigidbody.position).normalized;
            float distance = Vector3.Distance(_rigidbody.position, position);

            int count = Physics.BoxCastNonAlloc(
                _boxCollider.bounds.center,
                _boxCollider.bounds.extents * _boxCastExtentsMultiplier,
                direction,
                _hits,
                _bottle.transform.rotation,
                distance,
                _groundMask);

            return count == 0;
        }
    }
}