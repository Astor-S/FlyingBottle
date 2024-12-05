using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action FailedCollide;
    public event Action FinishedCollide;

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Ground>(out _))
    //        FailedCollide?.Invoke();

    //    if(collision.gameObject.TryGetComponent<FinishPortal>(out _))
    //        FinishedCollide?.Invoke();   
        
    //    if(collision.gameObject.TryGetComponent(out Crate crate))
    //        transform.parent = crate.transform;  
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            FailedCollide?.Invoke();

        if (collision.gameObject.TryGetComponent<FinishPortal>(out _))
            FinishedCollide?.Invoke();

        if (collision.gameObject.TryGetComponent(out Crate crate))
            transform.parent = crate.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Crate>(out _))
            transform.parent = null;
    }

    //private void OnTriggerExit(Collider collision)
    //{
    //    if (collision.gameObject.TryGetComponent <Crate>(out _))
    //        transform.parent = null;
    //}
}