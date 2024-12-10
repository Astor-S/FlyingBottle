using DG.Tweening;
using UnityEngine;

public class ToyCar : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private AudioClip _toyCarSound;
    [SerializeField] private float _duration;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            transform.DOMove(_target.position, _duration)
                     .SetEase(Ease.Linear);

            _audioSource.PlayOneShot(_toyCarSound);
        }
    }
}