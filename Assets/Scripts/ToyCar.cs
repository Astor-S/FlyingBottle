using DG.Tweening;
using UnityEngine;

public class ToyCar : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            transform.DOMove(_target.position, _duration)
                     .SetEase(Ease.Linear);
        }
    }
}