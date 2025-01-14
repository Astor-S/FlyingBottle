using UnityEngine;

namespace Objects.Effects
{
    public class SoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioClip _sound;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerControlSystem.Player>(out _))
                _audioSource.PlayOneShot(_sound);
        }
    }
}