using UI.Home.Interfaces;
using UnityEngine;

namespace UI.Home.MainMenu.SettingsMenu
{
    public class CloseSettings : MonoBehaviour, IMenuButton
    {
        [SerializeField] private SettingsScreen _settingsMenu;

        public void OnButtonClick()
        {
            _settingsMenu.Close();
        }
    }
}