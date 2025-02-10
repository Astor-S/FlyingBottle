using System;

namespace UI.Home.MainMenu
{
    public class LevelMenuButton : MenuButton
    {
        public event Action OnOpenLevelMenu;

        public override void OnButtonClick() =>
            OnOpenLevelMenu?.Invoke();
    }
}