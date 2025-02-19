using System;

namespace UI.Home.AudioSystem
{
    public static class AudioEventHandler
    {
        public static event Action<bool> SoundStateChanged;

        public static void NotifySoundStateChanged(bool state) =>
            SoundStateChanged?.Invoke(state);
    }
}