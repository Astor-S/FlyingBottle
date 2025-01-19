using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI.Home.MainMenu.SettingsMenu
{
    public class SoundToggle : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;

        private void Awake()
        {
            LoadSoundSettings();
            AudioService.InitializeAudio();
        }

        public void OnValueChanged()
        {
            UpdateSoundSettings();
        }

        private void UpdateSoundSettings()
        {
            AudioService.SetSoundState(_toggle.isOn);
        }

        private void LoadSoundSettings()
        {
            SavesYG saves = YandexGame.savesData;

            _toggle.isOn = saves.isSoundOn;
        }
    }
}