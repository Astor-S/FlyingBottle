using System;

namespace UI.Home.LevelMenu
{
    public class CloseLevelMenuButton : MenuButton
    {
        public event Action ClosedLevelMenu;

        public override void OnButtonClick() =>
            ClosedLevelMenu?.Invoke();
    }
}