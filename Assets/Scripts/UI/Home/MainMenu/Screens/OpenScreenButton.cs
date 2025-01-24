using UI.Home.Interfaces;
using UnityEngine;

namespace UI.Home.MainMenu.Screens
{
    public class OpenScreenButton : MonoBehaviour, IMenuButton
    {
        [SerializeField] private ScreenInMainMenu _screenMainMenu;

        public void OnButtonClick()
        {
            _screenMainMenu.Open();
        }
    }
}