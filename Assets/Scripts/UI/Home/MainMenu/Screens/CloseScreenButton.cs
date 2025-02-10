using UnityEngine;

namespace UI.Home.MainMenu.Screens
{
    public class CloseScreenButton : MenuButton
    {
        [SerializeField] private ScreenInMainMenu _screenMainMenu;

        public override void OnButtonClick() =>
            _screenMainMenu.Close();
    }
}