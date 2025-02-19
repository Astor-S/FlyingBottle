using System;

namespace UI.Home.ShopMenu
{
    public class CloseShopButton : MenuButton
    {
        public event Action ClosedShop;

        public override void OnButtonClick() =>
            ClosedShop?.Invoke();
    }
}