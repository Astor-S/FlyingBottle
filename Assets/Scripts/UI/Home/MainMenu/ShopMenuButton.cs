using System;

namespace UI.Home.MainMenu
{
    public class ShopMenuButton : MenuButton
    {
        public event Action OnOpenShop;

        public override void OnButtonClick() =>
            OnOpenShop?.Invoke();
    }
}