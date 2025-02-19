using System;

namespace UI.Home.MainMenu
{
    public class ShopMenuButton : MenuButton
    {
        public event Action OpenedShop;

        public override void OnButtonClick() =>
            OpenedShop?.Invoke();
    }
}