using UnityEngine;
using YG;

namespace UI.Home
{
    public static class AudioService
    {
        public static void SetSoundState(bool state)
        {
            SavesYG saves = YandexGame.savesData;
            saves.isSoundOn = state;
            UpdateAllAudioSources();
            YandexGame.SaveProgress();
        }

        public static void UpdateAllAudioSources()
        {
            SavesYG saves = YandexGame.savesData;
            AudioSource[] allAudioSources = Object.FindObjectsOfType<AudioSource>();

            foreach (AudioSource source in allAudioSources)
                source.mute = saves.isSoundOn == false; 
        }

        public static void InitializeAudio()
        {
            SavesYG saves = YandexGame.savesData;
            AudioSource[] allAudioSources = Object.FindObjectsOfType<AudioSource>();

            foreach (AudioSource source in allAudioSources)
                source.mute = saves.isSoundOn == false;  
        }
    }
}