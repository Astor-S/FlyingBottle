using YG;

namespace UI.Home.AudioSystem
{
    public static class AudioService
    {
        public static void SetSoundState(bool state)
        {
            SavesYG saves = YandexGame.savesData;
            saves.isSoundOn = state;
            AudioEventHandler.NotifySoundStateChanged(state);
            YandexGame.SaveProgress();
        }

        public static void InitializeAudio()
        {
            SavesYG saves = YandexGame.savesData;
            AudioEventHandler.NotifySoundStateChanged(saves.isSoundOn);
        }
    }
}