using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action FailedCollide;
    public event Action FinishedCollide;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            FailedCollide?.Invoke();

        if(collision.gameObject.TryGetComponent<FinishPortal>(out _))
            FinishedCollide?.Invoke();       
    }
}