using UnityEngine;

namespace UI.Home.MainMenu.SettingsMenu
{
    public class CloseSettings : MenuButton
    {
        [SerializeField] private SettingsScreen _settingsMenu;

        public override void OnButtonClick() =>
            _settingsMenu.Close();
    }
}