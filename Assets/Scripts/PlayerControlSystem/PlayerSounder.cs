using UnityEngine;

namespace PlayerControlSystem
{
    public class PlayerSounder : MonoBehaviour
    {
        [SerializeField] private AudioClip _jumpSound;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayJumpSound() =>
           _audioSource.PlayOneShot(_jumpSound);
    }
}