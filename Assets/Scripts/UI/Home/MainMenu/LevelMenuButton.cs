using System;

namespace UI.Home.MainMenu
{
    public class LevelMenuButton : MenuButton
    {
        public event Action OpenedLevelMenu;

        public override void OnButtonClick() =>
            OpenedLevelMenu?.Invoke();
    }
}