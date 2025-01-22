using System;
using UnityEngine;

namespace PlayerControlSystem
{
    public class CollisionDetector : MonoBehaviour
    {
        private bool _levelCompleted = false;

        public event Action FailedCollide;
        public event Action FinishedCollide;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Objects.Floor>(out _))
                FailedCollide?.Invoke();

            if (collision.gameObject.TryGetComponent<Objects.FinishPortal>(out _) && _levelCompleted == false)
            {
                FinishedCollide?.Invoke();
                _levelCompleted = true;
            }

            if (collision.gameObject.TryGetComponent(out Objects.MovingObject movingObject))
                transform.parent = movingObject.transform;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Objects.MovingObject>(out _))
                transform.parent = null;
        }
    }
}