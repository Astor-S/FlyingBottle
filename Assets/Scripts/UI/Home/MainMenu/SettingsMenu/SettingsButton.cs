using UI.Home.Interfaces;
using UnityEngine;

namespace UI.Home.MainMenu.SettingsMenu
{
    public class SettingsButton : MonoBehaviour, IMenuButton
    {
        [SerializeField] private SettingsScreen _settingsMenu;

        public void OnButtonClick()
        {
            _settingsMenu.Open();
        }
    }
}