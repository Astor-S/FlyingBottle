using UnityEngine;
using UnityEngine.UI;

namespace UI.Home.MainMenu.SettingsMenu
{
    public class SoundToggle : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;

        private void Awake()
        {
            UpdateSoundSettings();
        }

        public void OnValueChanged()
        {
            UpdateSoundSettings();
        }

        private void UpdateSoundSettings()
        {
            AudioService.IsSoundEnabled = _toggle.isOn;
            AudioService.UpdateAllAudioSources();
        }
    }
}