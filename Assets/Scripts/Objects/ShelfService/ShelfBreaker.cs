using System;
using UnityEngine;

namespace ShelfService
{
    public class ShelfBreaker : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioClip _shelfSound;
        [SerializeField] private string _breakAnimationTrigger = "Break";

        private AudioSource _audioSource;

        public event Action ShelfBreak;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerControlSystem.Player>(out _))
            {
                _animator.SetTrigger(_breakAnimationTrigger);
                ShelfBreak?.Invoke();
                _audioSource.PlayOneShot(_shelfSound);
            }
        }
    }
}