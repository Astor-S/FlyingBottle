using UnityEngine;

namespace PlayerControlSystem
{
    public class GroundChecker : MonoBehaviour
    {
        //private const float CheckDistance = 0.001f;

        //private readonly RaycastHit[] _results = new RaycastHit[1];

        private bool _isGrounded = false;
        private float _groundPositionY = float.NegativeInfinity;

        //    [SerializeField] private LayerMask _groundMask;
        //    [SerializeField] private float _extents = 0.42f;

        //    public bool IsGrounded(out float groundPositionY)
        //    {
        //        int count = Physics.BoxCastNonAlloc(transform.position, new Vector3(_extents, _extents, _extents), Vector3.down, _results, Quaternion.identity, CheckDistance, _groundMask);

        //        var isGrounded = count > 0;

        //        if (count > 0)
        //        {
        //            groundPositionY = _results[0].point.y;
        //        }
        //        else
        //        {
        //            groundPositionY = float.NegativeInfinity;
        //        }

        //        return isGrounded;
        //    }
        //}

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Ground>(out _))
            {
                _isGrounded = true;
                _groundPositionY = collision.contacts[0].point.y;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Ground>(out _))
            {
                _isGrounded = false;
                _groundPositionY = float.NegativeInfinity;
            }
        }

        public bool IsGrounded(out float groundPositionY)
        {
            groundPositionY = _groundPositionY;
            
            return _isGrounded;
        }
    }
}