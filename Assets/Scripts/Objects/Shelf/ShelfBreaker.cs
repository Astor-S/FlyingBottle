using System;
using UnityEngine;

public class ShelfBreaker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _shelfSound;
    [SerializeField] private string _breakAnimationTrigger = "Break";

    private AudioSource _audioSource;

    public event Action OnShelfBreak;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            _animator.SetTrigger(_breakAnimationTrigger);
            OnShelfBreak?.Invoke();
            _audioSource.PlayOneShot(_shelfSound);
        }
    }
}