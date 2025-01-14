using UnityEngine;

namespace PlayerControlSystem
{
    public class GroundChecker : MonoBehaviour
    {
        private bool _isGrounded = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Objects.Ground>(out _))
                _isGrounded = true;   
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Objects.Ground>(out _))
                _isGrounded = false;
        }

        public bool IsGrounded() =>
            _isGrounded;
    }
}