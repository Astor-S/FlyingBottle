using UnityEngine;

namespace UI.Home.MainMenu.SettingsMenu
{
    public class SettingsButton : MenuButton
    {
        [SerializeField] private SettingsScreen _settingsMenu;

        public override void OnButtonClick() =>
            _settingsMenu.Open();
    }
}