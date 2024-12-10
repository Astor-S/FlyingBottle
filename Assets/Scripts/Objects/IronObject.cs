using UnityEngine;

public class IronObject : MonoBehaviour
{
    [SerializeField] private AudioClip _ironSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            _audioSource.PlayOneShot(_ironSound);
    }
}