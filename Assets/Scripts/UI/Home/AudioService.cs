using UnityEngine;

namespace UI.Home
{
    public static class AudioService
    {
        public static bool IsSoundEnabled { get; set; } = true;

        public static void ToggleSound()
        {
            IsSoundEnabled = IsSoundEnabled == false;
            UpdateAllAudioSources();
        }

        public static void UpdateAllAudioSources()
        {
            AudioSource[] allAudioSources = Object.FindObjectsOfType<AudioSource>();
            
            foreach (AudioSource source in allAudioSources)
            {
                source.mute = IsSoundEnabled == false;
            }
        }
    }
}