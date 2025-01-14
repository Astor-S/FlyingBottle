using System;
using UnityEngine;

namespace PlayerControlSystem
{
    public class CollisionDetector : MonoBehaviour
    {
        public event Action FailedCollide;
        public event Action FinishedCollide;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Objects.Floor>(out _))
                FailedCollide?.Invoke();

            if (collision.gameObject.TryGetComponent<Objects.FinishPortal>(out _))
                FinishedCollide?.Invoke();

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