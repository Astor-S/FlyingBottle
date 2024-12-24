using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action FailedCollide;
    public event Action FinishedCollide;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Floor>(out _))
            FailedCollide?.Invoke();

        if (collision.gameObject.TryGetComponent<FinishPortal>(out _))
            FinishedCollide?.Invoke();

        if (collision.gameObject.TryGetComponent(out MovingObject movingObject))
            transform.parent = movingObject.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<MovingObject>(out _))
            transform.parent = null;
    }
}