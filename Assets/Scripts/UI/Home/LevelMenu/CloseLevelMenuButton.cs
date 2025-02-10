using System;

namespace UI.Home.LevelMenu
{
    public class CloseLevelMenuButton : MenuButton
    {
        public event Action OnCloseLevelMenu;

        public override void OnButtonClick() =>
            OnCloseLevelMenu?.Invoke();
    }
}