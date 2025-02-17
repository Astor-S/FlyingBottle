using UnityEngine;

namespace PlayerControlSystem
{
    public class PlayerRotator : MonoBehaviour
    {
        private const float FullRotationDegrees = -360f;

        [SerializeField] private Bottle _bottle;
        [SerializeField] private AnimationCurve _rotationCurve;
        [SerializeField] private Transform _rotationAnchor;
        [SerializeField][Range(0, 1)] private float _rotationStartTime = 0.2f;
        [SerializeField][Range(0, 1)] private float _rotationEndTime = 0.8f;

        private float _currentRotationAngle;
        private bool _isRotating;

        public bool IsRotating => _isRotating;

        public void UpdateRotation(PlayerMover playerMover, float currentTime)
        {
            if (currentTime > playerMover.JumpDuration * _rotationStartTime && currentTime < playerMover.JumpDuration * _rotationEndTime)
                _isRotating = true;
            else if (currentTime >= playerMover.JumpDuration * _rotationEndTime)
                _isRotating = false;

            if (currentTime < playerMover.JumpDuration * _rotationStartTime || currentTime > playerMover.JumpDuration * _rotationEndTime)
                return;

            float normalizedRotationTime = Mathf.InverseLerp(
                  playerMover.JumpDuration * _rotationStartTime,
                  playerMover.JumpDuration * _rotationEndTime,
                  currentTime);

            float rotationCurveValue = _rotationCurve.Evaluate(normalizedRotationTime);
            float rotationAngle = FullRotationDegrees * rotationCurveValue;
            float deltaRotation = rotationAngle - _currentRotationAngle;

            _currentRotationAngle = rotationAngle;

            _bottle.transform.RotateAround(_rotationAnchor.position, Vector3.forward, deltaRotation);
        }

        public void StopRotation() =>
            _isRotating = false;

        public void ResetCurrentRotationAngle() =>
            _currentRotationAngle = 0f;

        public void ResetRotation() =>
            _bottle.transform.rotation = Quaternion.identity;
    }
}