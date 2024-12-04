using System;
using UnityEngine;

public class ShelfBreaker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _breakAnimationTrigger = "Break";

    public event Action OnShelfBreak;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            _animator.SetTrigger(_breakAnimationTrigger);
            OnShelfBreak?.Invoke();
        }
    }
}