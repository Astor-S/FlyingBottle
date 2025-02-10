using System;

namespace UI.Home.ShopMenu
{
    public class CloseShopButton : MenuButton
    {
        public event Action OnCloseShop;

        public override void OnButtonClick() =>
            OnCloseShop?.Invoke();
    }
}