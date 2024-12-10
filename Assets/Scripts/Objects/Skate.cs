using UnityEngine;

public class Skate : MonoBehaviour
{
    [SerializeField] private AudioClip _skateSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            _audioSource.PlayOneShot(_skateSound);
    }
}