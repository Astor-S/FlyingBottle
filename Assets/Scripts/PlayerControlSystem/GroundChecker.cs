using UnityEngine;

namespace PlayerControlSystem
{
    public class GroundChecker : MonoBehaviour
    {
        private const float CheckDistance = 0.001f;

        private readonly RaycastHit[] _results = new RaycastHit[1];

        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _extents = 0.42f;

        public bool IsGrounded(out float groundPositionY)
        {
            int count = Physics.BoxCastNonAlloc(transform.position, new Vector3(_extents, _extents, _extents), Vector3.down, _results, Quaternion.identity, CheckDistance, _groundMask);

            var isGrounded = count > 0;

            if (count > 0)
            {
                groundPositionY = _results[0].point.y;
            }
            else
            {
                groundPositionY = float.NegativeInfinity;
            }

            return isGrounded;
        }
    }
}