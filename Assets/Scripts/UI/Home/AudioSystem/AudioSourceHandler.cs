using UnityEngine;

namespace UI.Home.AudioSystem
{
    public class AudioSourceHandler : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            AudioEventHandler.SoundStateChanged += OnSoundStateChanged;
        }

        private void OnDestroy()
        {
            AudioEventHandler.SoundStateChanged -= OnSoundStateChanged;
        }

        private void OnSoundStateChanged(bool state) =>
            _audioSource.mute = state == false;
    }
}